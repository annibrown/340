using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    public CharacterData characterData;
    private SpriteRenderer sr;
    
    public Character inLoveWithCharacter;
    
    private bool playerInRange = false;
    //private Transform player;
    
    private Character pendingLoveTarget; // Hidden during round
    public bool hasBeenEnchantedThisRound = false;
    
    
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Keyboard.current.eKey.wasPressedThisFrame)
        {
            // enchant character with the potion player is holding
            // make it love potion for testing
            Debug.Log("Enchanted With Love");
        }
    }
    
    public void Initialize(CharacterData data)
    {
        characterData = data;

        // Assign sprite
        if (characterData.appearance != null)
            sr.sprite = characterData.appearance;
    }
    
    // Called when player uses potion
    public void EnchantWith(Character target)
    {
        pendingLoveTarget = target;
        hasBeenEnchantedThisRound = true;
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
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger Enter: " + other.name);
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            //player = other.transform;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Trigger Exit: " + other.name);
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
