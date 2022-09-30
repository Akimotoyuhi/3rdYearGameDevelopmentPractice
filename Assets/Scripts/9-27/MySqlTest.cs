using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;

public class MySqlTest : MonoBehaviour
{
    [SerializeField] GUIManager m_guiManager;
    private string m_servar = "127.0.0.1"; //localhost
    private string m_database = "vantan";
    private string m_user_id = "root";
    private string m_port = "3306";
    private string m_password = "";

    public void ConnectDatabase(ConnectType connectType, string name = "")
    {
        MySqlConnection con = null;
        MySqlDataReader reader = null;
        string conCmd = $"server={m_servar};database={m_database};userid={m_user_id};port={m_port};password={m_password}";
        //Debug.Log(conCmd);
        try
        {
            con = new MySqlConnection(conCmd);
            con.Open();
            string selCon = "";
            MySqlCommand cmd = null;
            switch (connectType)
            {
                case ConnectType.ShowButton:
                    selCon = "SELECT * FROM monster";
                    cmd = new MySqlCommand(selCon, con);
                    reader = cmd.ExecuteReader();
                    //全てのモンスターを拾ってきてボタンとして表示させる
                    while (reader.Read())
                    {
                        Debug.Log("NAME : " + reader.GetString("NAME"));
                        ViewGUI(reader.GetString("NAME"));
                    }
                    break;
                case ConnectType.SetData:
                    reader = ExecuteReader(con, reader, "SELECT * FROM monster_defeat_count;");
                    while (reader.Read())
                    {
                        Debug.Log("NAME : " + reader.GetString("NAME"));
                        //登録済み(倒したことがある)のモンスターがいれば、カウントを１上げる
                        if (reader.GetString("NAME") == name)
                        {
                            reader = ExecuteReader(con, reader, $"SELECT mdc.count FROM monster_defeat_count mdc WHERE name = '{name}';");
                            Debug.Log(reader.Read());
                            reader.Close();
                            int count = int.Parse(reader.GetString("COUNT"));
                            count++;
                            selCon = $"UPDATE monster_defeat_count SET count = '{count}' WHERE name = '{name}';";
                            cmd = new MySqlCommand(selCon, con);
                            cmd.ExecuteNonQuery();
                            
                            //ExecuteReader(con, reader, $"UPDATE monster_defeat_count SET count = '{count}' WHERE name = '{name}';");
                            return;
                        }
                    }
                    reader.Close();
                    //いなければ追加を行う
                    Debug.Log("新規データを追加");
                    selCon = $"INSERT INTO monster_defeat_count VALUES('{name}','1');";
                    cmd = new MySqlCommand(selCon, con);
                    cmd.ExecuteNonQuery();
                    //reader = cmd.ExecuteNonQuery();
                    //ExecuteReader(con, reader, $"INSERT INTO monster_defeat_count VALUES({name},1);");
                    break;
                default:
                    break;
            }
        }
        catch (MySqlException ex)
        {
            Debug.Log(ex.ToString());
        }
        finally
        {
            reader.Close();
            con.Close();
        }
    }

    private MySqlDataReader ExecuteReader(MySqlConnection con, MySqlDataReader reader, string sql)
    {
        string selCon = sql;
        MySqlCommand cmd = new MySqlCommand(selCon, con);
        reader = cmd.ExecuteReader();
        return reader;
    }

    private void ViewGUI(string name)
    {
        m_guiManager.CreateButton(name, () =>
        {
            Debug.Log($"{name}を倒した");
            ConnectDatabase(ConnectType.SetData, name);
        });
    }
}

public enum ConnectType
{
    ShowButton,
    SetData,
}