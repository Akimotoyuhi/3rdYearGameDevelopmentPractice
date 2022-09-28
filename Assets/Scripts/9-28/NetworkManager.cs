using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;

public class NetworkManager : MonoBehaviour
{
    public async UniTask Request(string url, System.Action callBack)
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        await www.SendWebRequest();
        string text = www.downloadHandler.text;
        Debug.Log(text);
        callBack();
    }
}
