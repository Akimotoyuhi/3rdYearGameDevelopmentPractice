using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SELECT * FROM monster
public class MonsterManager : MonoBehaviour
{
    //[SerializeField] string m_sql;
    [SerializeField] MySqlTest m_mySqlText;

    void Start()
    {
        m_mySqlText.ConnectDatabase(ConnectType.ShowButton);
    }
}
