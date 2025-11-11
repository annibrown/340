using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    private string characterName;
    private Character inLoveWith;
    //private Player enchantedBy;
    
    // for testing
    public bool enchantedWithLove = false;
    
    private bool playerInRange = false;
    //private Transform player;
    
    
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
            enchantedWithLove = true;
            
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            //player = other.transform;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
