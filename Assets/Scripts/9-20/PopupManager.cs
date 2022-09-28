using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    [SerializeField] Popup _popup;

    private void Start()
    {
        Popup popup = Instantiate(_popup);
        popup.Setup();
        //popup.Init("�^�C�g��", "�{��", () => Debug.Log("Cancel"), () => Debug.Log("OK"));
        popup.Init("�^�C�g��", "�{��", null, () => Debug.Log("OK"));
    }
}
