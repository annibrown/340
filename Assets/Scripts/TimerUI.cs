using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    public Text timerText; 
    
    public GameTimer gameTimer;
    
    void Update()
    {
        if (gameTimer != null && gameTimer.IsRunning())
        {
            timerText.text = gameTimer.GetTimeAsString();
        }
    }
}
