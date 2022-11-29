using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Cysharp.Threading.Tasks;
using MySql.Data.MySqlClient;

public class PhpDBResult : MonoBehaviour
{
    [SerializeField] PhpDBResultText m_prefab;
    [SerializeField] Transform m_parent;
    private string m_servar = "127.0.0.1"; //localhost
    private string m_database = "vantan";
    private string m_user_id = "root";
    private string m_port = "3306";
    private string m_password = "";

    private void Start()
    {
        ConnectResultData();
    }

    private void ConnectResultData()
    {
        MySqlConnection con = null;
        MySqlDataReader reader = null;
        string conCmd = $"server={m_servar};database={m_database};userid={m_user_id};port={m_port};password={m_password}";
        try
        {
            con = new MySqlConnection(conCmd);
            con.Open();
            string selCon = "SELECT * FROM monster_defeat_count;";
            MySqlCommand cmd = new MySqlCommand(selCon, con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                PhpDBResultText obj = PhpDBResultText.Init(m_prefab, reader.GetString("name"), reader.GetInt32("count").ToString());
                obj.transform.SetParent(m_parent, false);
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
        reader.Close();
        con.Close();
    }
}
