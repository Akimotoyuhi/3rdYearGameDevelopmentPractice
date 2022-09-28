using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.Networking;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;

//課題 じゃんけん
//Unity上でグーチョキパーいずれかのボタンを押せるようにして、押したボタンをphpにGETで送信
//phpは押された手を受け取り、CPUの手を決めて、勝敗を判定してからデータを返却
//Unity上で結果を表示

//課題２　じゃんけん改造
//じゃんけん結果をJsonに変換
//C#でJsonを受け取り結果表示

public class Janken : MonoBehaviour
{
    [SerializeField] JankenHand m_gu;
    [SerializeField] JankenHand m_tyoki;
    [SerializeField] JankenHand m_pa;
    [SerializeField] Image m_cpuImage;
    [SerializeField] Image m_playerImage;
    [SerializeField] Text m_resultText;
    [SerializeField] List<HandSprite> m_handSprites;
    [System.Serializable]
    public class HandSprite
    {
        [SerializeField] Hand m_hand;
        [SerializeField] Sprite m_sprite;
        public Hand Hand => m_hand;
        public Sprite Sprite => m_sprite;
    }
    private string m_url = "http://localhost/Janken.php?hand={hand}";

    void Start()
    {
        List<JankenHand> hands = new List<JankenHand>();
        m_gu.Hand = (int)Hand.Gu;
        hands.Add(m_gu);
        m_tyoki.Hand = (int)Hand.Tyoki;
        hands.Add(m_tyoki);
        m_pa.Hand = (int)Hand.Pa;
        hands.Add(m_pa);
        hands.ForEach(h => h.HandSubject.Subscribe(hand => OnClick(hand)).AddTo(h));
    }

    private async void OnClick(int hand)
    {
        Debug.Log($"{hand}が押された");
        string url = m_url.Replace("{hand}", hand.ToString());
        UnityWebRequest www = UnityWebRequest.Get(url);
        await www.SendWebRequest();
        Debug.Log(www.downloadHandler.text);
        JankenResult result = JsonUtility.FromJson<JankenResult>(www.downloadHandler.text);
        ShowResult((Hand)result.hand_id, (Hand)result.cpu_hand_id, (Result)result.result);
        //string[] vs = www.downloadHandler.text.Split(',');
        //List<int> lists = new List<int>();
        //foreach (var v in vs)
        //    lists.Add(int.Parse(v));
        //ShowResult((Hand)lists[0], (Hand)lists[1], (Result)lists[2]);
    }

    private void ShowResult(Hand playerHand, Hand cpuHand, Result result)
    {
        m_handSprites.ForEach(h =>
        {
            if (h.Hand == playerHand)
                m_playerImage.sprite = h.Sprite;
            if (h.Hand == cpuHand)
                m_cpuImage.sprite = h.Sprite;
        });
        switch (result)
        {
            case Result.Drow:
                m_resultText.text = "引き分け";
                break;
            case Result.Win:
                m_resultText.text = "勝ち";
                break;
            case Result.Lose:
                m_resultText.text = "負け";
                break;
        }
    }
}

[System.Serializable]
public class JankenResult
{
    public int hand_id;
    public int cpu_hand_id;
    public int result;
}

public enum Hand
{
    Gu,
    Tyoki,
    Pa,
}
public enum Result
{
    Drow,
    Win,
    Lose,
}