using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhpDBResultText : MonoBehaviour
{
    [SerializeField] Text m_nameText;
    [SerializeField] Text m_countText;

    public static PhpDBResultText Init(PhpDBResultText original, string name, string count)
    {
        PhpDBResultText ret = Instantiate(original);
        ret.Setup(name, count);
        return ret;
    }

    private void Setup(string name, string count)
    {
        m_nameText.text = name;
        m_countText.text = count;
    }
}
