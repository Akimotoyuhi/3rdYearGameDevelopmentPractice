using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;

public class NetworkManager : MonoBehaviour
{
    public static NetworkManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public async UniTask Request(string url, System.Action<SampleModel> callBack)
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        await www.SendWebRequest();
        Debug.Log(www.downloadHandler.text);
        SampleModel model = JsonUtility.FromJson<SampleModel>(www.downloadHandler.text);
        callBack(model);
    }
}