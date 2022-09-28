using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Sample : MonoBehaviour
{
    [SerializeField] InputField m_inputField;
    [SerializeField] Text m_viewText;

    void Start()
    {
        string aaa = "ijauhfo";
        Debug.Log(nameof(aaa));

        //Ex1();
        //Ex2();
    }

    /// <summary>
    /// 1����100�܂ł̍��v�l���o��
    /// </summary>
    private void Ex1()
    {
        Debug.Log("�ۑ�P");
        int total = default;
        for (int i = 1; i <= 100; i++)
        {
            total += i;
        }
        Debug.Log(total);
    }

    /// <summary>
    /// 1����30�܂ł̐��l���o��(FizzBuzz)<br/>
    /// 5�̔{����Buzz�A3�̔{����Fizz�A3��5�Ȃ��FizzBuzz
    /// </summary>
    private void Ex2()
    {
        Debug.Log("�ۑ�Q");
        for (int i = 1; i <= 30; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
                Debug.Log($"{i} = FizzBuzz");
            else if (i % 5 == 0)
                Debug.Log($"{i} = Buzz");
            else if (i % 3 == 0)
                Debug.Log($"{i} = Fizz");
        }
    }

    /// <summary>
    /// �񕶔���<br/>Button����Ă΂��
    /// </summary>
    public void Ex3()
    {
        Debug.Log("�ۑ�R");
        if (!m_viewText || !m_inputField)
            return;
        string s = new string(m_inputField.text.Reverse().ToArray());
        Debug.Log($"{m_inputField.text} {s}");
        if (m_inputField.text == s)
            m_viewText.text = "Yes";
        else
            m_viewText.text = "No";
    }
}
