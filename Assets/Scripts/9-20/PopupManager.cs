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
        //popup.Init("タイトル", "本文", () => Debug.Log("Cancel"), () => Debug.Log("OK"));
        popup.Init("タイトル", "本文", null, () => Debug.Log("OK"));
    }
}
