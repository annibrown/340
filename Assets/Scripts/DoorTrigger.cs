using UnityEngine;
using UnityEngine.InputSystem;

public class DoorTrigger : MonoBehaviour
{
    public Transform teleportDestination;  // Drag your DoorDestination here
    private bool playerInRange = false;
    private Transform player;

    void Update()
    {
        if (playerInRange && Keyboard.current.eKey.wasPressedThisFrame)
        {
            DialogueManager.Instance.ShowChoice(
                "Enter?",
                OnYesPressed,
                OnNoPressed,
                "Yes",
                "No"
            );
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            player = other.transform;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    void OnYesPressed()
    {
        if (teleportDestination != null && player != null)
        {
            player.position = teleportDestination.position;
        }
    }

    void OnNoPressed()
    {
        Debug.Log("Player said no.");
    }
}


