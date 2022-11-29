using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UniRx;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] string m_nextSceneName;
    [SerializeField] Button m_sceneChangeButton;

    void Start()
    {
        m_sceneChangeButton.OnClickAsObservable()
            .Subscribe(_ => SceneManager.LoadScene(m_nextSceneName))
            .AddTo(this);
    }
}
