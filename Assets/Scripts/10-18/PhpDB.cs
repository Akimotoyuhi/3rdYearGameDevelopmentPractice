using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using Cysharp.Threading.Tasks;
using MySql.Data.MySqlClient;
using UniRx;

public class PhpDB : MonoBehaviour
{
    [SerializeField] string m_url;
    [SerializeField] PhpDBButton m_button;
    [SerializeField] Transform m_buttonParent;
    private string m_servar = "127.0.0.1"; //localhost
    private string m_database = "vantan";
    private string m_user_id = "root";
    private string m_port = "3306";
    private string m_password = "";

    void Start()
    {
        //NetworkManager.Instance.Request<Monsters>(m_url, model => Hoge(model)).Forget();
        Request(m_url, model => ShowGUI(model)).Forget();
    }

    public async UniTask Request(string url, System.Action<Monsters> callBack)
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        await www.SendWebRequest();
        Debug.Log(www.downloadHandler.text);
        string json = www.downloadHandler.text;
        json = json.Insert(0, "{\"Items\":");
        json += "}";
        //json = json.Replace("[{", "{\"Items\":[{");
        //json = json.Replace("}]", "}]}");
        Debug.Log(json);
        var model = JsonUtility.FromJson<Monsters>(json);
        Debug.Log(model.Items[0].NAME);
        callBack(model);
    }

    private void ShowGUI(Monsters model)
    {
        foreach (var item in model.Items)
        {
            PhpDBButton b = PhpDBButton.Init(m_button, item, () =>
            {
                Debug.Log($"{item.NAME}を倒した");
                AddCount(item.NAME);
            });
            b.transform.SetParent(m_buttonParent, false);
        }
    }

    private void AddCount(string name)
    {
        MySqlConnection con = null;
        MySqlDataReader reader = null;
        string conCmd = $"server={m_servar};database={m_database};userid={m_user_id};port={m_port};password={m_password}";
        try
        {
            con = new MySqlConnection(conCmd);
            con.Open();
            string selCon = "";
            MySqlCommand cmd = null;
            reader = ExecuteReader(con, reader, "SELECT * FROM monster_defeat_count;");
            while (reader.Read())
            {
                //Debug.Log("NAME : " + reader.GetString("NAME"));
                Debug.Log($"NAME : {name}");
                //登録済み(倒したことがある)のモンスターがいれば、カウントを１上げる
                if (reader.GetString("NAME") == name)
                {
                    reader.Close();
                    reader = ExecuteReader(con, reader, $"SELECT mdc.count FROM monster_defeat_count mdc WHERE name = '{name}';");
                    Debug.Log($"{name}を更新");
                    reader.Read();
                    int count = reader.GetInt32("count");
                    count++;
                    Debug.Log("カウントアップ");
                    reader.Close();
                    selCon = $"UPDATE monster_defeat_count SET count = '{count}' WHERE name = '{name}';";
                    cmd = new MySqlCommand(selCon, con);
                    cmd.ExecuteNonQuery();
                    return;
                }
            }
            reader.Close();
            //いなければ追加を行う
            Debug.Log("新規データを追加");
            selCon = $"INSERT INTO monster_defeat_count VALUES(null,'{name}','1');";
            cmd = new MySqlCommand(selCon, con);
            cmd.ExecuteNonQuery();
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

    private MySqlDataReader ExecuteReader(MySqlConnection con, MySqlDataReader reader, string sql)
    {
        string selCon = sql;
        MySqlCommand cmd = new MySqlCommand(selCon, con);
        reader = cmd.ExecuteReader();
        return reader;
    }
}

[System.Serializable]
public class MonsterModel
{
    public string NAME;
    public int BREED;
    public string ALIAS;
    public int ATTRIBUTE;
    public string HOME;
    public int IS_SUB;
    public int STRIPPING_COUNT;
    public int FIRST_TITLE;
}

[System.Serializable]
public class Monsters
{
    public MonsterModel[] Items;
}