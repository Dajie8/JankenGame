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

    [SerializeField] Result resultType;

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

    public Result GetResult(HandType myHand, HandType cpuHand)
    {
        switch(myHand)
        {
            case HandType.Rock:
               switch(cpuHand)
               {
                   case HandType.Rock:
                       return Result.Drew;
                    case HandType.Scissor:
                       return Result.Win;
                    case HandType.Papor:
                       return Result.Lose;
               }
               return Result.Lose;
            
            case HandType.Scissor:
               switch(cpuHand)
               {
                   case HandType.Rock:
                       return Result.Lose;
                    case HandType.Scissor:
                        return Result.Drew;
                    case HandType.Papor:
                        return Result.Win;
               }
               return Result.Lose;

            case HandType.Papor:
                switch(cpuHand)
                {
                    case HandType.Rock:
                        return Result.Win;
                    case HandType.Scissor:
                        return Result.Lose;
                    case HandType.Papor:
                        return Result.Drew;
                }
                return Result.Lose;
        }
        return Result.Lose;
    }

    public void OnclickRetry()
    {
        SceneManager.LoadScene("JankenStart");
    }
}