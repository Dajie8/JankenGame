using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public enum HandType
{
    Rock = 1,
    Scissor = 2,
    Papor = 3,
}

public enum Result
{
    Win = 1,
    Lose = 2,
    Drew = 3,
}

public class jankenResult : MonoBehaviour
{
    [SerializeField] Image myHand;

    [SerializeField] Image cpuHand;

    [SerializeField] TextMeshProUGUI resultText;

    private Result resultType;

    private void Start()
    {
        Setup();
    }

    private void Setup()
    {
        var Data = Resources.Load<myHandData>("myHandData");
        var cpuHandNum = Random.Range(1,3);

        myHand.sprite = Resources.Load<Sprite>(string.Format("HandImage/{0}",Data.playerHand));
        cpuHand.sprite = Resources.Load<Sprite>(string.Format("HandImage/{0}",cpuHandNum));

        //var resultType = GetResult((HandType)Data.playerHand,(HandType)cpuHandNum);
        switch(resultType)
        {
            case Result.Win:
                resultText.text = "WIN";
                break;
            case Result.Lose:
                resultText.text = "LOSE";
                break;
            case Result.Drew:
                resultText.text = "DREW";
                break;
        }
    }
}