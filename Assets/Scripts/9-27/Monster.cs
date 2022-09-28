using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;

public class Monster : MonoBehaviour
{
    MySqlConnection con = new MySqlConnection("server=localhost;uid=root;pwd=mypass;database=tekito");

    void Start()
    {
        
    }
}
