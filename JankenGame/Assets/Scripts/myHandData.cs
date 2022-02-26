using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
[CreateAssetMenu(menuName = "playerHandData")]
public class myHandData : ScriptableObject
{
    [SerializeField] private int _playerHand = 0;
    public int playerHand
    {
        get => _playerHand;
        set => _playerHand = value;
    }
}