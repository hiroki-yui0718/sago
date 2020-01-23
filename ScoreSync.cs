using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ScoreSync : MonoBehaviourPunCallbacks
{
    public Text RedText;
    public Text BlueText;
    private int RedScore = 0;
    private int BlueScore = 0;
    private new PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {

        if (photonView.IsMine == false) {  }
       

            Debug.Log("True1");
            photonView.RPC(nameof(Score), RpcTarget.All, DestroyUnit.RedScore, DestroyUnit.BlueScore);
        
       
        

    }
    [PunRPC]
    void Score(int score1,int score2)
    {
        RedScore += score1;　//③変数+変化を指定
        Debug.Log("Red:" + RedScore);
        RedText.text = RedScore.ToString();
        DestroyUnit.RedScore = 0;
        BlueScore += score2;　//③変数+変化を指定
        Debug.Log("Blue:"+BlueScore);
        BlueText.text = BlueScore.ToString();
        DestroyUnit.BlueScore = 0;
    }
}
