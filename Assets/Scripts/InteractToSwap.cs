using UnityEngine;
using UnityEngine.InputSystem;

public class InteractToSwap : MonoBehaviour
{
    public GameObject objectToHide;     // Usually this object
    public GameObject objectToShow;     // The object that appears
    private bool playerInRange = false;

    void Update()
    {
        // If player is in range and presses E
        if (playerInRange && Keyboard.current.eKey.wasPressedThisFrame)
        {
            Debug.Log("Restore Statue");
            if (objectToHide != null) objectToHide.SetActive(false);
            if (objectToShow != null) objectToShow.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger Enter: " + other.name);
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Trigger Exit: " + other.name);
        if (other.CompareTag("Player"))
            playerInRange = false;
    }
}

