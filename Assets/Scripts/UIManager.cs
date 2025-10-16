using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject gamePanel;
    public GameObject settingsPanel;

    void Start()
    {
        startPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void PlayButtonClicked() 
    {
        Time.timeScale = 1;
        startPanel.SetActive(false);
        gamePanel.SetActive(true);
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
    }

    public void MenuButtonClicked()
    {
        startPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }
}
