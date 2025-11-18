using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject gamePanel;
    public GameObject settingsPanel;
    public GameObject timerPanel;
    public GameTimer gameTimer;
    public GameObject resultsPanel;
    
    public RoundManager roundManager;
    
    void Start()
    {
        startPanel.SetActive(true);
        timerPanel.SetActive(false);
        Time.timeScale = 0;
    }
    public void PlayButtonClicked() 
    {
        Time.timeScale = 1;
        startPanel.SetActive(false);
        gamePanel.SetActive(true);
        timerPanel.SetActive(true);

        roundManager.StartNewRound();
    }

    public void ShowResults()
    {
        resultsPanel.SetActive(true);
    }

    public void HideResults()
    {
        resultsPanel.SetActive(false);
    }
    public void SettingsButtonClicked()
    {
        
    }

    public void QuitButtonClicked()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (gamePanel.activeInHierarchy)
            {
                Time.timeScale = 0;
                settingsPanel.SetActive(true);
                gamePanel.SetActive(false);
            }
        }
    }

    public void ResumeButtonClicked()
    {
        Time.timeScale = 1;
        gamePanel.SetActive(true);
        settingsPanel.SetActive(false);
        // resume timer
        gameTimer.ResumeTimer();
    }

    public void MenuButtonClicked()
    {
        startPanel.SetActive(true);
        settingsPanel.SetActive(false);
        // pause timer
        gameTimer.PauseTimer();
    }
}
