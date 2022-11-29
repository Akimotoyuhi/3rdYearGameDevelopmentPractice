using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class PhpDBButton : MonoBehaviour
{
    [SerializeField] Button m_button;
    [SerializeField] Text m_text;

    private void Setup(MonsterModel monsterModel, System.Action onClick)
    {
        m_button.OnClickAsObservable().Subscribe(x => onClick());
        m_text.text = monsterModel.NAME;
    }

    public static PhpDBButton Init(PhpDBButton original, MonsterModel monsterModel, System.Action onClick)
    {
        PhpDBButton ret = Instantiate(original);
        ret.Setup(monsterModel, onClick);
        return ret;
    }
}
