using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System;

public class jankenScene : MonoBehaviour
{
    private myHandData Data ;

    private void Awake()
    {
        Data = Resources.Load<myHandData>("myHandData");
        if (Data.playerHand > 0)
        {
            Data.playerHand = 0;
        }
    }

    public void OnTapButton(int playerHandNum)
    {
        Data.playerHand = playerHandNum;
        SceneManager.LoadScene("JankenResult");
    }
}
