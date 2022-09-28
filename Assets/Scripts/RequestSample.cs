using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

public class RequestSample : MonoBehaviour
{
    [SerializeField] RawImage m_img;

    private async void Start()
    {
        //UnityWebRequest www = UnityWebRequest.Get("http://localhost/recipe.html");
        UnityWebRequest www = UnityWebRequestTexture.GetTexture("https://aceship.github.io/AN-EN-Tags/img/avatars/char_377_gdglow.png");
        await www.SendWebRequest();
        //Debug.Log(www.downloadHandler.text);
        m_img.texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
    }
}
