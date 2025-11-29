using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
    public CharacterManager characterManager;
    public List<Player> players = new List<Player>();
    public GameTimer gameTimer;
    
    public float roundDuration = 60f; // 60 seconds per roundpublic float roundTimer;
    private int currentRound = 0;
    
    public GameObject resultsScreen;
    public Text resultsText;
    private String results;
    
    public UIManager UIManager;
    
    public void StartNewRound()
    {
        Debug.Log("Starting new round");
        Time.timeScale = 1;
        UIManager.HideResults();
        currentRound++;
        
        Debug.Log("=== ROUND " + currentRound + " START ===");
        
        // Reset all players' potions
        foreach (Player player in players)
        {
            player.ResetForNewRound();
        }
        
        gameTimer.StartTimer((int)roundDuration, EndRound);
        // Note: Character love relationships persist between rounds
    }
    
    public void EndRound()
    {
        Debug.Log("=== ROUND " + currentRound + " END ===");
        
        // Reveal all relationships
        RevealRelationships();
        
        // Calculate scores
        CalculateScores();
        
        UIManager.ShowResults();
        Time.timeScale = 0;
        
        // Wait a bit before starting next round (you can add a UI delay here)
        Invoke("StartNewRound", 10f);
    }
    
    void RevealRelationships()
    {
        results = "";
        
        Debug.Log("--- Current Relationships ---");
        foreach (Character character in characterManager.spawnedCharacters)
        {
            if (character.inLoveWithCharacter != null)
            {
                Debug.Log(character.characterData.characterName + " loves " + character.inLoveWithCharacter.characterData.characterName);
                results += character.characterData.characterName + " loves " +
                           character.inLoveWithCharacter.characterData.characterName + "\n";
            }
            else
            {
                Debug.Log(character.characterData.characterName + " is not in love");
            }
        }

        resultsText.text = results;
    }
    
    void CalculateScores()
    {
        // You'll implement scoring based on each player's goal
        // For now, just log who made which pairs
        
        foreach (Player player in players)
        {
            if (player.enchantedCharacters.Count == 2)
            {
                Character char1 = player.enchantedCharacters[0];
                Character char2 = player.enchantedCharacters[1];
                
                // Check if they're actually in love (mutual)
                if (char1.inLoveWithCharacter == char2 && char2.inLoveWithCharacter == char1)
                {
                    Debug.Log(player.playerID + " successfully paired " + 
                             char1.characterData.characterName + " and " + 
                             char2.characterData.characterName);
                }
            }
        }
    }
    
    public int GetCurrentRound()
    {
        return currentRound;
    }
}
