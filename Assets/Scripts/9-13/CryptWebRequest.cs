using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Security.Cryptography;

//�ۑ�P
//�N���C�A���g����"���͂悤"������ꂫ���ꍇ��"���͂悤�������܂�"�A����ȊO�̏ꍇ��"���悤�Ȃ�"���o�͂���

public class CryptWebRequest : MonoBehaviour
{
    const string data = "���͂悤";

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
    //    RijndaelManaged rijnael = new RijndaelManaged();                        //�Í����A���������T�|�[�g����N���X�̃C���X�^���X���쐬
    //    rijnael.KeySize = 128;
    //    rijnael.BlockSize = 128;
    //    //rijnael.Key = Encoding.UTF8.GetBytes(AesKey);
    //    //rijnael.IV = Encoding.UTF8.GetBytes(AesIV);

    //    //�Í���
    //    ICryptoTransform encryptor = rijnael.CreateEncryptor();                 //�ΏۈÍ������ꂽ�I�u�W�F�N�g�𐶐��i�H�j
    //    byte[] encrypted = encryptor.TransformFinalBlock(src, 0, src.Length);   //0�`src�̒����܂ł̃o�C�g�z��𕡍����@���s�����CryptographicException������
    //    encryptor.Dispose();
    //}
}
