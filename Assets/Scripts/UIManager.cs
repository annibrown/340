using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public CharacterManager characterManager;
    public Player player;
    
    public GameObject startPanel;
    public GameObject gamePanel;
    public GameObject settingsPanel;
    public GameObject timerPanel;
    public GameTimer gameTimer;
    public GameObject resultsPanel;
    public GameObject goalPanel;
    
    // ASSIGN SCREEN
    public GameObject assignPanel;
    public Text characterOneText;
    public Text characterTwoText;
    public Text characterOneGoalText;
    public Text characterTwoGoalText;
    
    // MUSIC
    public GameObject TitleMusic;
    public GameObject BackgroundMusic1;
    public GameObject BackgroundMusic2;
    public GameObject ScoreMusic;
    
    public RoundManager roundManager;
    
    void Start()
    {
        startPanel.SetActive(true);
        timerPanel.SetActive(false);
        Time.timeScale = 0;
        assignPanel.SetActive(false);
        TitleMusic.SetActive(true);
        goalPanel.SetActive(false);
    }
    public void PlayButtonClicked() 
    {
        AudioManager.Instance.Play(AudioManager.SoundType.Button);
        startPanel.SetActive(false);
        
        // assign characters to players
        AssignCharacters();
        
        assignPanel.SetActive(true);
        
        PlayBackgroundMusic();
        
        Debug.Log("Starting Coroutine");
        StartCoroutine(StartGameAfterDelay(5f));
    }

    public void PlayBackgroundMusic()
    {
        TitleMusic.SetActive(false);
        ScoreMusic.SetActive(false);
        //BackgroundMusic1.SetActive(true);
        BackgroundMusic2.SetActive(true);
    }

    private void AssignCharacters()
    {
        characterManager.Shuffle(characterManager.spawnedCharacters);
        
        Character char1 = characterManager.spawnedCharacters[0];
        Character char2 = characterManager.spawnedCharacters[1];
        
        player.assignedCharacters.Add(char1);
        player.assignedCharacters.Add(char2);
        
        characterOneText.text = char1.characterData.characterName;
        characterOneText.color = char1.characterData.characterColor;
        
        characterTwoText.text = char2.characterData.characterName;
        characterTwoText.color = char2.characterData.characterColor;
        
        characterOneGoalText.text = char1.characterData.characterName;
        characterOneGoalText.color = char1.characterData.characterColor;
        
        characterTwoGoalText.text = char2.characterData.characterName;
        characterTwoGoalText.color = char2.characterData.characterColor;
    }

    private IEnumerator StartGameAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay); // This ignores Time.timeScale!
        StartGame();
    }

    public void StartGame()
    {
        Debug.Log("Starting Game");
        assignPanel.SetActive(false);
        gamePanel.SetActive(true);
        timerPanel.SetActive(true);
        goalPanel.SetActive(true);
        roundManager.StartNewRound();
    }

    public void ShowResults()
    {
        BackgroundMusic1.SetActive(false);
        BackgroundMusic2.SetActive(false);
        ScoreMusic.SetActive(true);
        resultsPanel.SetActive(true);
    }

    public void HideResults()
    {
        ScoreMusic.SetActive(false);
        resultsPanel.SetActive(false);
    }
    public void SettingsButtonClicked()
    {
        AudioManager.Instance.Play(AudioManager.SoundType.Button);
    }

    public void QuitButtonClicked()
    {
        AudioManager.Instance.Play(AudioManager.SoundType.Button);
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
        AudioManager.Instance.Play(AudioManager.SoundType.Button);
        Time.timeScale = 1;
        gamePanel.SetActive(true);
        settingsPanel.SetActive(false);
        // resume timer
        gameTimer.ResumeTimer();
    }

    public void MenuButtonClicked()
    {
        AudioManager.Instance.Play(AudioManager.SoundType.Button);
        startPanel.SetActive(true);
        settingsPanel.SetActive(false);
        // pause timer
        gameTimer.PauseTimer();
    }
    
    public void ResultsContinueButtonClicked()
    {
        AudioManager.Instance.Play(AudioManager.SoundType.Button);
        roundManager.StartNewRound();
    }
}
