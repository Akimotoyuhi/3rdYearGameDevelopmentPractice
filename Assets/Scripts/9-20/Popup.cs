using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Cysharp.Threading.Tasks;

public class Popup : MonoBehaviour
{
    [SerializeField] GameObject _popupObject;
    [SerializeField] Text _titleText;
    [SerializeField] Text _bodyText;
    [SerializeField] Button _cancelButton;
    [SerializeField] Button _okButton;
    [SerializeField] Animation _anim;
    [SerializeField] AnimationClip _fadeinClip;
    [SerializeField] AnimationClip _fadeoutClip;
    private System.Action _okAction;
    private System.Action _cancelAction;

    public void Setup()
    {
        //_popupObject.SetActive(false);
        _titleText.text = "";
        _bodyText.text = "";
        //OKボタンの入力を受け取る
        _okButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                _okAction.Invoke();
                ButtonClick();
            })
            .AddTo(_okButton);
        _okButton.gameObject.SetActive(false);
        //キャンセルボタンの入力を受け取る
        _cancelButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                _cancelAction.Invoke();
                ButtonClick();
            })
            .AddTo(_cancelButton);
        _cancelButton.gameObject.SetActive(false);
    }

    public async void Init(string title, string body, System.Action cancelAction, System.Action okAction)
    {
        //_popupObject.SetActive(true);
        await Fade(FadeType.In);
        _titleText.text = title;
        _bodyText.text = body;
        _okAction = okAction;
        _cancelAction = cancelAction;
        SetButtonActive();
    }

    /// <summary>
    /// ボタンの表示非表示の切り替え
    /// </summary>
    private void SetButtonActive()
    {
        if (_okAction == null)
        {
            _okButton.gameObject.SetActive(false);
        }
        else
        {
            _okButton.gameObject.SetActive(true);
        }

        if (_cancelAction == null)
        {
            _cancelButton.gameObject.SetActive(false);
        }
        else
        {
            _cancelButton.gameObject.SetActive(true);
        }
    }

    private async UniTask Fade(FadeType fadeType)
    {
        float f = 0;
        switch (fadeType)
        {
            case FadeType.In:
                _anim.clip = _fadeinClip;
                _anim.Play();
                f = _fadeinClip.length * 1000;
                break;
            case FadeType.Out:
                _anim.clip = _fadeoutClip;
                _anim.Play();
                f = _fadeoutClip.length * 1000;
                break;
            default:
                break;
        }
        await UniTask.Delay((int)f);
    }

    /// <summary>
    /// ボタンクリック時の共通処理
    /// </summary>
    private async void ButtonClick()
    {
        //_popupObject.SetActive(false);
        _titleText.text = "";
        _bodyText.text = "";
        _okButton.gameObject.SetActive(false);
        _cancelButton.gameObject.SetActive(false);
        await Fade(FadeType.Out);
        Destroy(gameObject);
    }
}

public enum FadeType
{
    In,
    Out,
}
