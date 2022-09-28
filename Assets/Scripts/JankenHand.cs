using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class JankenHand : MonoBehaviour
{
    [SerializeField] Button m_button;
    private Subject<int> m_handSubject = new Subject<int>();
    public int Hand { private get; set; }
    public System.IObservable<int> HandSubject => m_handSubject;

    private void Start()
    {
        m_button.onClick.AddListener(() => m_handSubject.OnNext(Hand));
    }
}
