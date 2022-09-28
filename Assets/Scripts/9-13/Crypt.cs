using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Security.Cryptography;

public class Crypt : MonoBehaviour
{
    const string AesIV = "1234567890123456";
    const string AesKey = "9283948908019888";
    const string data = "おはよう";

    void Start()
    {
        byte[] src = Encoding.UTF8.GetBytes(data);
        RijndaelManaged rijnael = new RijndaelManaged();                        //暗号化、複合化をサポートするクラスのインスタンスを作成
        rijnael.KeySize = 128;
        rijnael.BlockSize = 128;
        rijnael.Key = Encoding.UTF8.GetBytes(AesKey);
        rijnael.IV = Encoding.UTF8.GetBytes(AesIV);

        //暗号化
        ICryptoTransform encryptor = rijnael.CreateEncryptor();                 //対象暗号化されたオブジェクトを生成（？）
        byte[] encrypted = encryptor.TransformFinalBlock(src, 0, src.Length);   //0～srcの長さまでのバイト配列を複合化　失敗するとCryptographicExceptionが発生
        encryptor.Dispose();                                                    //廃棄
        Debug.Log(Encoding.UTF8.GetString(src));
        Debug.Log(Encoding.UTF8.GetString(encrypted));

        Decrypt(src);
    }

    private void Decrypt(byte[] src)
    {
        //byte[] src = Encoding.UTF8.GetBytes(data);
        RijndaelManaged rijnael = new RijndaelManaged();                        //暗号化、複合化をサポートするクラスのインスタンスを作成
        rijnael.KeySize = 128;
        rijnael.BlockSize = 128;
        rijnael.Key = Encoding.UTF8.GetBytes(AesKey);
        rijnael.IV = Encoding.UTF8.GetBytes(AesIV);

        //暗号化
        ICryptoTransform encryptor = rijnael.CreateDecryptor();                 //対象暗号化されたオブジェクトを生成（？）
        byte[] encrypted = encryptor.TransformFinalBlock(src, 0, src.Length);   //0～srcの長さまでのバイト配列を複合化　失敗するとCryptographicExceptionが発生
        encryptor.Dispose();                                                    //廃棄
        Debug.Log(Encoding.UTF8.GetString(src));
        Debug.Log(Encoding.UTF8.GetString(encrypted));
    }
}
