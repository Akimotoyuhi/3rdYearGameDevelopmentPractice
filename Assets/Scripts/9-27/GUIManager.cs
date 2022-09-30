using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    [SerializeField] MonsterButtonObject m_monsterButtonPrefab;
    [SerializeField] Transform m_buttonParent;

    public void CreateButton(string text, System.Action clickAction)
    {
        MonsterButtonObject obj = Instantiate(m_monsterButtonPrefab);
        obj.SetText = text;
        obj.GetButtonObservable.Subscribe(_ => clickAction()).AddTo(obj);
        obj.transform.SetParent(m_buttonParent, false);
    }
}
