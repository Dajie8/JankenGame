using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public enum HandType
{
    Rock = 0,
    Scissor = 1,
    Papor = 2,
}

public enum ResultType
{
    Win = 0,
    Lose = 1,
    Drew = 2,
}

public class JankenResult : MonoBehaviour
{
    [SerializeField] Image myHandImage;

    [SerializeField] Image cpuHandImage;

    [SerializeField] TextMeshProUGUI resultText;


    private void Start()
    {
        Setup();
    }

    private void Setup()
    {
        var data = Resources.Load<MyHandData>("myHandData");
        var cpuHandNum = Random.Range(0,3);
        var result = getResult((HandType)data.playerHand,(HandType)cpuHandNum);
       
        myHandImage.sprite = Resources.Load<Sprite>(string.Format("handImage/{0}",data.playerHand));
        cpuHandImage.sprite = Resources.Load<Sprite>(string.Format("handImage/{0}", cpuHandNum));
        Debug.Log(data);

        switch(result)
        {
            case ResultType.Win:
                resultText.text = "WIN";
                break;
            case ResultType.Lose:
                resultText.text = "LOSE";
                break;
            case ResultType.Drew:
                resultText.text = "DREW";
                break;
            default:
                break;
        }
    }

    public ResultType getResult(HandType myHand, HandType cpuHand)
    {
        switch(myHand)
        {
            case HandType.Rock:
               switch(cpuHand)
               {
                   case HandType.Rock:
                       return ResultType.Drew;
                    case HandType.Scissor:
                       return ResultType.Win;
                    case HandType.Papor:
                       return ResultType.Lose;
               }
               return ResultType.Lose;
            
            case HandType.Scissor:
               switch(cpuHand)
               {
                   case HandType.Rock:
                       return ResultType.Lose;
                    case HandType.Scissor:
                        return ResultType.Drew;
                    case HandType.Papor:
                        return ResultType.Win;
               }
               return ResultType.Lose;

            case HandType.Papor:
                switch(cpuHand)
                {
                    case HandType.Rock:
                        return ResultType.Win;
                    case HandType.Scissor:
                        return ResultType.Lose;
                    case HandType.Papor:
                        return ResultType.Drew;
                }
                return ResultType.Lose;
        }
        return ResultType.Lose;
    }

    public void OnclickRetry()
    {
        SceneManager.LoadScene("JankenStart");
    }
}