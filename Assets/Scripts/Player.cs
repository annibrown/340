using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerID;
    
    // Track which characters this player has enchanted this round
    public List<Character> enchantedCharacters = new List<Character>();
    
    // Maximum potions per round
    public int maxPotionsPerRound = 2;
    
    // Current potions available
    private int remainingPotions;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       remainingPotions = maxPotionsPerRound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public bool CanEnchant()
    {
        return remainingPotions > 0 && enchantedCharacters.Count < maxPotionsPerRound;
    }

    // adds character to player's list if they successfully get enchanted
    public void EnchantCharacterWithLovePotion(Character target)
    { 
        if (!CanEnchant())
        {
            Debug.Log("No potions remaining!");
            return;
        }
        
        // Remove any previous enchantment by this player on this character
        if (target.enchantedByPlayer != null && target.enchantedByPlayer == this)
        {
            Debug.Log("Already enchanted this character!");
            return;
        }
        
        // Remove previous player's enchantment if it exists
        if (target.enchantedByPlayer != null)
        {
            target.enchantedByPlayer.RemoveEnchantment(target);
        }
        
        // Apply new enchantment
        target.enchantedByPlayer = this;
        enchantedCharacters.Add(target);
        remainingPotions--;
        
        Debug.Log(playerID + " enchanted " + target.characterData.characterName + 
                  " (" + remainingPotions + " potions remaining)");
        
        // Check if this creates a pair
        CheckForPair();
        // remove character from any other players' lists
    }
    
    private void CheckForPair()
    {
        // Need exactly 2 enchanted characters to form a pair
        if (enchantedCharacters.Count == 2)
        {
            Character char1 = enchantedCharacters[0];
            Character char2 = enchantedCharacters[1];
            
            // Make them fall in love with each other
            char1.inLoveWithCharacter = char2;
            char2.inLoveWithCharacter = char1;
            
            Debug.Log(char1.characterData.characterName + " and " + 
                      char2.characterData.characterName + " are now in love!");
        }
    }
    
    public void RemoveEnchantment(Character character)
    {
        if (enchantedCharacters.Contains(character))
        {
            enchantedCharacters.Remove(character);
            
            // Break any pair that involved this character
            if (enchantedCharacters.Count == 1)
            {
                // The remaining character is no longer in a pair
                Character remaining = enchantedCharacters[0];
                remaining.inLoveWithCharacter = null;
            }
            
            Debug.Log(playerID + "'s enchantment on " + character.characterData.characterName + " was removed");
        }
    }
    
    public void ResetForNewRound()
    {
        // Clear enchantments but keep love relationships
        enchantedCharacters.Clear();
        remainingPotions = maxPotionsPerRound;
        Debug.Log(playerID + " potions reset for new round");
    }
}
