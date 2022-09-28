using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.Networking;

public class GetAddResult : MonoBehaviour
{
    [SerializeField] int num1;
    [SerializeField] int num2;

    void Start()
    {
        AddResult();
    }

    private async void AddResult()
    {
        string url = $"http://localhost/add_result2.php?value1={num1}&value2={num2}";
        UnityWebRequest www = UnityWebRequest.Get(url);
        await www.SendWebRequest();
        Debug.Log(www.downloadHandler.text);
    }
}
