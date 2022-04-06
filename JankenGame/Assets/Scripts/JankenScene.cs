using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System;

public class JankenScene : MonoBehaviour
{
    private MyHandData handData ;

    public void Awake()
    {
        handData = Resources.Load<MyHandData>("myHandData");
        if (handData.playerHand > 0)
        {
            handData.playerHand = 0;
        }
    }

    public void OnTapButton(int playerHandNum)
    {
        handData.playerHand = playerHandNum;
        SceneManager.LoadScene("JankenResult");
    }
}
