using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class MonsterButtonObject : MonoBehaviour
{
    [SerializeField] Button m_button;
    [SerializeField] Text m_text;

    public System.IObservable<Unit> GetButtonObservable => m_button.OnClickAsObservable();
    public string SetText { set => m_text.text = value; }

}
