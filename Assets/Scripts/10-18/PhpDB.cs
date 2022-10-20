using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Cysharp.Threading.Tasks;

public class PhpDB : MonoBehaviour
{
    [SerializeField] string m_url;

    void Start()
    {
        //NetworkManager.Instance.Request<Monsters>(m_url, model => Hoge(model)).Forget();
        Request(m_url, model => Hoge(model)).Forget();
    }

    public async UniTask Request(string url, System.Action<Monsters> callBack)
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        await www.SendWebRequest();
        Debug.Log(www.downloadHandler.text);
        string json = www.downloadHandler.text;
        json = json.Replace("[{", "{\"Items\":[");
        //json = json.Replace("]", "}}");
        Debug.Log(json);
        var model = JsonUtility.FromJson<Monsters>(json);
        Debug.Log(model);
        callBack(model);
    }

    private void Hoge(Monsters model)
    {
        //Debug.Log(model);
        //Debug.Log(model.models[0].NAME);
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