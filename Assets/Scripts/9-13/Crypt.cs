using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Security.Cryptography;

public class Crypt : MonoBehaviour
{
    const string AesIV = "1234567890123456";
    const string AesKey = "9283948908019888";
    const string data = "���͂悤";

    void Start()
    {
        byte[] src = Encoding.UTF8.GetBytes(data);
        RijndaelManaged rijnael = new RijndaelManaged();                        //�Í����A���������T�|�[�g����N���X�̃C���X�^���X���쐬
        rijnael.KeySize = 128;
        rijnael.BlockSize = 128;
        rijnael.Key = Encoding.UTF8.GetBytes(AesKey);
        rijnael.IV = Encoding.UTF8.GetBytes(AesIV);

        //�Í���
        ICryptoTransform encryptor = rijnael.CreateEncryptor();                 //�ΏۈÍ������ꂽ�I�u�W�F�N�g�𐶐��i�H�j
        byte[] encrypted = encryptor.TransformFinalBlock(src, 0, src.Length);   //0�`src�̒����܂ł̃o�C�g�z��𕡍����@���s�����CryptographicException������
        encryptor.Dispose();                                                    //�p��
        Debug.Log(Encoding.UTF8.GetString(src));
        Debug.Log(Encoding.UTF8.GetString(encrypted));

        Decrypt(src);
    }

    private void Decrypt(byte[] src)
    {
        //byte[] src = Encoding.UTF8.GetBytes(data);
        RijndaelManaged rijnael = new RijndaelManaged();                        //�Í����A���������T�|�[�g����N���X�̃C���X�^���X���쐬
        rijnael.KeySize = 128;
        rijnael.BlockSize = 128;
        rijnael.Key = Encoding.UTF8.GetBytes(AesKey);
        rijnael.IV = Encoding.UTF8.GetBytes(AesIV);

        //�Í���
        ICryptoTransform encryptor = rijnael.CreateDecryptor();                 //�ΏۈÍ������ꂽ�I�u�W�F�N�g�𐶐��i�H�j
        byte[] encrypted = encryptor.TransformFinalBlock(src, 0, src.Length);   //0�`src�̒����܂ł̃o�C�g�z��𕡍����@���s�����CryptographicException������
        encryptor.Dispose();                                                    //�p��
        Debug.Log(Encoding.UTF8.GetString(src));
        Debug.Log(Encoding.UTF8.GetString(encrypted));
    }
}
