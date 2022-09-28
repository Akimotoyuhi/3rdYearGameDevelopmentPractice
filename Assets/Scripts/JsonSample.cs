using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Cysharp.Threading.Tasks;

public class JsonSample : MonoBehaviour
{
    [SerializeField] string m_url = "http://localhost/Sample.json";

    async void Start()
    {
        UnityWebRequest www = UnityWebRequest.Get(m_url);
        await www.SendWebRequest();
        //Debug.Log(www.downloadHandler.text);
        UserModel model = JsonUtility.FromJson<UserModel>(www.downloadHandler.text);
        Debug.Log($"{model.user_id}, {model.name}, {model.is_login}");
        for (int i = 0; i < model.hobby.Length; i++)
        {
            Debug.Log($"Hobby{i}, {model.hobby[i]}");
        }
        //Birth birth = JsonUtility.FromJson<Birth>(model.birth);
    }
}

[System.Serializable]
public class UserModel
{
    public int user_id;
    public string name;
    public bool is_login;
    public string[] hobby;
    public Birth birth;
}
[System.Serializable]
public class Birth
{
    public int year;
    public int month;
    public int day;
}
