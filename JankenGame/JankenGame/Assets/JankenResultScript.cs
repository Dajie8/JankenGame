using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class JankenResultScript : MonoBehaviour
{
    //Player(自分)っていうGameObjectですよ～って変数を定義してる？ごめん日本語わからん
    [SerializeField] GameObject player;

    //Computer(相手)
    [SerializeField] GameObject computer;

    //Result(結果表示)
    [SerializeField] TextMeshProUGUI result;

    //これわかってない、解説欲しい。Sprite(画像呼び出す系？でグーチョキパーの値と合致させてるって感じ？)
    public Sprite[] MyHand = new Sprite[3];

    //相手の手をスプライト(たまに飲むと美味しい)
    public Sprite[] RandomHand = new Sprite[3];

    //じゃんけんの処理その1
    void Judge(){
        if(JankenStartScript.Instance.playerHand < JankenStartScript.Instance.cpuHand){
            result.gameObject.GetComponent<TextMeshProUGUI>().text = "WIN";
        }else
        {
            result.gameObject.GetComponent<TextMeshProUGUI>().text = "LOSE";
        }
    }

    //じゃんけんの処理その2
    void AnotherJudge(){
        if(JankenStartScript.Instance.playerHand > JankenStartScript.Instance.cpuHand){
            result.text = "WIN";
        }else
        {
            result.text = "LOSE";
        }
    }

    //Retryを押したときに最初の画面に遷移するよってやつ
    public void OnclickRetry(){
        SceneManager.LoadScene("JankenStart");
    }

    // Start is called before the first frame update
    void Start()
    {
        //いらんだろうけど俺が使ってたので記念に
        Debug.Log(JankenStartScript.Instance.playerHand);
        Debug.Log(JankenStartScript.Instance.cpuHand);
        
        //JankenStartScriptのMyHandとこっちのPlayerをイコールしてる感じ？
        player.gameObject.GetComponent<Image>().sprite = MyHand[JankenStartScript.Instance.playerHand];
        
        //上の相手版
        computer.gameObject.GetComponent<Image>().sprite = RandomHand[JankenStartScript.Instance.cpuHand];

        //じゃんけん処理の諸々＋引き分けパターン
        if(JankenStartScript.Instance.playerHand == JankenStartScript.Instance.cpuHand){
            result.text = "DREW";
        }else if(JankenStartScript.Instance.playerHand + JankenStartScript.Instance.cpuHand == 2)
        {
            AnotherJudge();
        }else
        {
            Judge();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
