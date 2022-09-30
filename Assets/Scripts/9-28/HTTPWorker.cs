using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;

public class HTTPWorker : MonoBehaviour
{
    [SerializeField] string m_url;

    private void Start()
    {
        NetworkManager.Instance.Request<SampleModel>(
            m_url,
            model => OnCompleate(model)).Forget();
    }

    private void OnCompleate(SampleModel model)
    {
        Debug.Log(model.name);
    }
}

[System.Serializable]
public class SampleModel
{
    public int user_id;
    public string name;
    public bool is_login;
    public string[] hobby;
    public Birth birth;
}
