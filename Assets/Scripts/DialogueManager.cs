using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    [Header("UI References")]
    public GameObject dialogueUI;
    public Text dialogueText;
    public Button yesButton;
    public Button noButton;

    private Text buttonOneText;
    private Text buttonTwoText;

    [Header("Dialogue Data")]
    public string[] dialogueLines;
    private int currentLine;
    private bool isDialogueActive;
    private bool isChoiceMode;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        dialogueUI.SetActive(false);
    }

    void Start()
    {
        buttonOneText = yesButton.GetComponentInChildren<Text>();
        buttonTwoText = noButton.GetComponentInChildren<Text>();

        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isDialogueActive && !isChoiceMode && (Mouse.current.leftButton.wasPressedThisFrame))
        {
            DisplayNextLine();
        }
    }

    // --- 1️⃣ Simple click-through dialogue ---
    public void StartDialogue(string[] lines)
    {
        dialogueLines = lines;
        currentLine = 0;
        isDialogueActive = true;
        isChoiceMode = false;

        dialogueUI.SetActive(true);
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);

        dialogueText.text = dialogueLines[currentLine];
    }

    private void DisplayNextLine()
    {
        currentLine++;

        if (currentLine < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLine];
        }
        else
        {
            EndDialogue();
        }
    }

    // --- 2️⃣ Dialogue with choices (buttons) ---
    public void ShowChoice(string message, Action onYes, Action onNo, string yesText = "Yes", string noText = "No")
    {
        dialogueUI.SetActive(true);
        isDialogueActive = true;
        isChoiceMode = true;

        dialogueText.text = message;

        yesButton.gameObject.SetActive(true);
        noButton.gameObject.SetActive(true);

        buttonOneText.text = yesText;
        buttonTwoText.text = noText;

        yesButton.onClick.RemoveAllListeners();
        noButton.onClick.RemoveAllListeners();

        yesButton.onClick.AddListener(() =>
        {
            onYes?.Invoke();
            EndDialogue();
        });

        noButton.onClick.AddListener(() =>
        {
            onNo?.Invoke();
            EndDialogue();
        });
    }

    private void EndDialogue()
    {
        isDialogueActive = false;
        dialogueUI.SetActive(false);

        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
    }
}
