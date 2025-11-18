using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    public CharacterData characterData;
    private SpriteRenderer sr;
    
    public Character inLoveWithCharacter;
    public Player enchantedByPlayer;
    
    private bool playerInRange = false;
    private Player nearbyPlayer;
    
    private Character pendingLoveTarget; // Hidden during round
    public bool hasBeenEnchantedThisRound = false;
    
    
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && nearbyPlayer != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            // Player attempts to enchant this character
            nearbyPlayer.EnchantCharacterWithLovePotion(this);
            // enchant character with the potion player is holding
            // make it love potion for testing
            Debug.Log("Enchanted With Love");
        }
    }
    
    public void Initialize(CharacterData data)
    {
        characterData = data;

        // Apply sprite if available, otherwise make sure we still have something to render
        if (characterData.appearance != null)
        {
            sr.sprite = characterData.appearance;
        }
        else if (sr.sprite == null)
        {
            // If no sprite assigned anywhere, create a basic square
            // Make sure your prefab has a sprite assigned in the SpriteRenderer
            Debug.LogWarning(characterData.characterName + " has no sprite assigned!");
        }
    
        // Apply color
        sr.color = characterData.characterColor;
    
        Debug.Log("Initialized " + characterData.characterName + " with color " + characterData.characterColor);
    }
    
    // Called when player uses potion
    public void EnchantWith(Character target)
    {
        pendingLoveTarget = target;
        hasBeenEnchantedThisRound = true;
        Debug.Log(characterData.characterName + " loves " + target.characterData.characterName);
    }
    
    // Called at round end
    public void ApplyEnchantment()
    {
        if (hasBeenEnchantedThisRound)
        {
            inLoveWithCharacter = pendingLoveTarget;
        }
        // Reset for next round
        hasBeenEnchantedThisRound = false;
        pendingLoveTarget = null;
    }
    
    // Method to make this character fall in love with another
    public void FallInLoveWith(Character target)
    {
        inLoveWithCharacter = target;
        Debug.Log(characterData.characterName + " is now in love with " + target.characterData.characterName);
    }
    
    public void ClearEnchantment()
    {
        if (enchantedByPlayer != null)
        {
            enchantedByPlayer.RemoveEnchantment(this);
            enchantedByPlayer = null;
        }
    }
    
    public bool IsEnchanted()
    {
        return enchantedByPlayer != null;
    }
    
    public bool IsInLove()
    {
        return inLoveWithCharacter != null;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger Enter: " + other.name);
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            nearbyPlayer = other.GetComponent<Player>();
            Debug.Log("Player " + nearbyPlayer.playerID + " is near " + characterData.characterName);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Trigger Exit: " + other.name);
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            nearbyPlayer = null;
        }
    }
}
