using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class JankenResultScript : MonoBehaviour
{
    [SerializeField] GameObject Player;

    [SerializeField] GameObject Computer;

    [SerializeField] TextMeshProUGUI Result;

    public Sprite[] MyHand = new Sprite[3];

    public Sprite[] RandomHand = new Sprite[3];

    void Keisan1(){
        if(JankenStartScript.Instance.PlayerHand < JankenStartScript.Instance.CpuHand){
            Result.gameObject.GetComponent<TextMeshProUGUI>().text = "WIN";
        }else
        {
            Result.gameObject.GetComponent<TextMeshProUGUI>().text = "LOSE";
        }
    }

    void Keisan2(){
        if(JankenStartScript.Instance.PlayerHand > JankenStartScript.Instance.CpuHand){
            Result.text = "WIN";
        }else
        {
            Result.text = "LOSE";
        }
    }

    public void OnclickRetry(){
        SceneManager.LoadScene("JankenStart");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(JankenStartScript.Instance.PlayerHand);
        Debug.Log(JankenStartScript.Instance.CpuHand);
        
        Player.gameObject.GetComponent<Image>().sprite = MyHand[JankenStartScript.Instance.PlayerHand];
        
        Computer.gameObject.GetComponent<Image>().sprite = RandomHand[JankenStartScript.Instance.CpuHand];

        if(JankenStartScript.Instance.PlayerHand == JankenStartScript.Instance.CpuHand){
            Result.text = "DREW";
        }else if(JankenStartScript.Instance.PlayerHand + JankenStartScript.Instance.CpuHand == 2)
        {
            Keisan2();
        }else
        {
            Keisan1();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
