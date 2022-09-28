using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Security.Cryptography;

//課題１
//クライアントから"おはよう"が送られきた場合は"おはようございます"、それ以外の場合は"さようなら"を出力せよ

public class CryptWebRequest : MonoBehaviour
{
    const string data = "おはよう";

    void Start()
    {
        Request();
    }

    private void Request()
    {
        byte[] b = Encoding.UTF8.GetBytes(data);
        //var cryptData = Encrypt(b);
    }

    //private byte[] Encrypt(byte[] bytes)
    //{
    //    RijndaelManaged rijnael = new RijndaelManaged();                        //暗号化、複合化をサポートするクラスのインスタンスを作成
    //    rijnael.KeySize = 128;
    //    rijnael.BlockSize = 128;
    //    //rijnael.Key = Encoding.UTF8.GetBytes(AesKey);
    //    //rijnael.IV = Encoding.UTF8.GetBytes(AesIV);

    //    //暗号化
    //    ICryptoTransform encryptor = rijnael.CreateEncryptor();                 //対象暗号化されたオブジェクトを生成（？）
    //    byte[] encrypted = encryptor.TransformFinalBlock(src, 0, src.Length);   //0～srcの長さまでのバイト配列を複合化　失敗するとCryptographicExceptionが発生
    //    encryptor.Dispose();
    //}
}
