using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ScoreSync : MonoBehaviourPunCallbacks
{
    public Text text1;
    public Text text2;
    private int score1 = 0;
    private int score2 = 0;
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
            photonView.RPC(nameof(Score1), RpcTarget.All, BaseScript.score1, ScoreScript.score1);
            photonView.RPC(nameof(Score2), RpcTarget.All, BaseScript.score2, ScoreScript.score2);

    }
    [PunRPC]
    void Score1(int one, int two)
    {
        Debug.Log("True2");
        score1 += one + two;　//③変数+変化を指定
        text1.text = score1.ToString();
        BaseScript.score1 = 0;  //⑤当たり判定・足し算初期化
        ScoreScript.score1 = 0;
    }
    [PunRPC]
    void Score2(int one, int two)
    {
        Debug.Log("True2");
        score2 += one + two;　//③変数+変化を指定
        text2.text = score2.ToString();
        BaseScript.score2 = 0;  //⑤当たり判定・足し算初期化
        ScoreScript.score2 = 0;
    }
}
