using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class JankenStartScript : MonoBehaviour
{
    public int PlayerHand;
    public int CpuHand;

    public readonly static JankenStartScript Instance = new JankenStartScript();

    public void OnclickRock(){
        JankenStartScript.Instance.PlayerHand = 0;
        SceneManager.LoadScene("JankenResult");
    }

    public void OnclickScissor(){
        JankenStartScript.Instance.PlayerHand = 1;
        SceneManager.LoadScene("JankenResult");
    }

    public void OnclickPapor(){
        JankenStartScript.Instance.PlayerHand = 2;
        SceneManager.LoadScene("JankenResult");
    }

    // Start is called before the first frame update
    void Start()
    {
        JankenStartScript.Instance.CpuHand = Random.Range(0,3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}