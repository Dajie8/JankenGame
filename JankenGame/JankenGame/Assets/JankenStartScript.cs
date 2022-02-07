using UnityEngine;
using UnityEngine.SceneManagement;

public class JankenStartScript : MonoBehaviour
{
    //自分の手の変数(合ってる？)
    public int playerHand;
    
    //相手の手の変数
    public int cpuHand;

    //よくわかってないけど、これで繰り返しじゃんけんできるようになる感じなの？
    public readonly static JankenStartScript Instance = new JankenStartScript();

    //グーを押した時
    public void OnclickRock(){
        JankenStartScript.Instance.playerHand = 0;
        SceneManager.LoadScene("JankenResult");
    }

    //チョキを押した時
    public void OnclickScissor(){
        JankenStartScript.Instance.playerHand = 1;
        SceneManager.LoadScene("JankenResult");
    }

    //パーを押した時
    public void OnclickPapor(){
        JankenStartScript.Instance.playerHand = 2;
        SceneManager.LoadScene("JankenResult");
    }

    // Start is called before the first frame update
    //相手の手をランダムで決める
    void Start()
    {
        JankenStartScript.Instance.cpuHand = Random.Range(0,3);
    }

    // Update is called once per frame
    //なにこれいる？わからん
    void Update()
    {
        
    }
}