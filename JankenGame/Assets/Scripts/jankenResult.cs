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

public enum ResultType
{
    Win = 1,
    Lose = 2,
    Drew = 3,
}

public class JankenResult : MonoBehaviour
{
    [SerializeField] Image myHandImage;

    [SerializeField] Image cpuHandImage;

    [SerializeField] TextMeshProUGUI resultText;

    [SerializeField] ResultType resultType;

    private void Start()
    {
        Setup();
    }

    private void Setup()
    {
        var Data = Resources.Load<MyHandData>("myHandData");
        var cpuHandNum = Random.Range(1,3);

        myHandImage.sprite = Resources.Load<Sprite>(string.Format("HandImage/{0}",Data.playerHand));
        cpuHandImage.sprite = Resources.Load<Sprite>(string.Format("HandImage/{0}",cpuHandNum));

        switch(resultType)
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
        }
    }

    public ResultType GetResult(HandType myHand, HandType cpuHand)
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