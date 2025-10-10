using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject gamePanel;
    public GameObject settingsPanel;
    
    public void PlayButtonClicked() 
    {
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
                settingsPanel.SetActive(true);
                gamePanel.SetActive(false);
            }
        }
    }

    public void ResumeButtonClicked()
    {
        gamePanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    public void MenuButtonClicked()
    {
        startPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }
}
