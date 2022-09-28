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
    /// 1から100までの合計値を出力
    /// </summary>
    private void Ex1()
    {
        Debug.Log("課題１");
        int total = default;
        for (int i = 1; i <= 100; i++)
        {
            total += i;
        }
        Debug.Log(total);
    }

    /// <summary>
    /// 1から30までの数値を出力(FizzBuzz)<br/>
    /// 5の倍数がBuzz、3の倍数がFizz、3と5ならばFizzBuzz
    /// </summary>
    private void Ex2()
    {
        Debug.Log("課題２");
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
    /// 回文判定<br/>Buttonから呼ばれる
    /// </summary>
    public void Ex3()
    {
        Debug.Log("課題３");
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
