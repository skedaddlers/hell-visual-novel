// Scripts/Gameplay/DialogueManager.cs
using UnityEngine;
using TMPro; // Pastikan sudah install TextMeshPro dari Package Manager
using UnityEngine.UI;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI characterNameText;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject choicesPanel;
    [SerializeField] private Button[] choiceButtons; // Buat 3 button di UI

    private Queue<DialogueLine> dialogueQueue;
    private List<Choice> currentChoices;
    private bool choicesDisplayed = false;

    void Start()
    {
        dialoguePanel.SetActive(false);
        choicesPanel.SetActive(false);
        dialogueQueue = new Queue<DialogueLine>();
    }

    public void StartDialogue(DialogueEventSO dialogueEvent)
    {
        choicesDisplayed = false;
        dialoguePanel.SetActive(true);
        choicesPanel.SetActive(false);

        dialogueQueue.Clear();
        foreach (var line in dialogueEvent.dialogueLines)
        {
            dialogueQueue.Enqueue(line);
        }

        currentChoices = dialogueEvent.choices;
        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        if (dialogueQueue.Count == 0 && !choicesDisplayed)
        {
            DisplayChoices();
            return;
        }
        else if (dialogueQueue.Count == 0 && choicesDisplayed)
        {
            GameManager.Instance.ProgressTime(); 
            return;
        }

        DialogueLine currentLine = dialogueQueue.Dequeue();
        characterNameText.text = currentLine.character.characterName;
        UIManager.Instance.ChangeCharacterSprite(currentLine.character);
        dialogueText.text = currentLine.line;
    }

    private void DisplayChoices()
    {
        choicesDisplayed = true;
        dialoguePanel.SetActive(false); // Sembunyikan panel dialog
        choicesPanel.SetActive(true);

        for (int i = 0; i < choiceButtons.Length; i++)
        {
            if (i < currentChoices.Count)
            {
                choiceButtons[i].gameObject.SetActive(true);
                choiceButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = currentChoices[i].choiceText;
                
                int choiceIndex = i; // Penting untuk menghindari masalah closure di lambda
                choiceButtons[i].onClick.RemoveAllListeners();
                choiceButtons[i].onClick.AddListener(() => OnChoiceSelected(choiceIndex));
            }
            else
            {
                choiceButtons[i].gameObject.SetActive(false);
            }
        }
    }

    private void OnChoiceSelected(int choiceIndex)
    {
        choicesPanel.SetActive(false);
        Choice selectedChoice = currentChoices[choiceIndex];

        // Terapkan semua efek dari pilihan
        foreach (var statChange in selectedChoice.statChanges)
        {
            StatsManager.Instance.ChangeStat(statChange.statToChange, statChange.amount);
        }

        if (!string.IsNullOrEmpty(selectedChoice.storyFlagToSet))
        {
            StatsManager.Instance.SetStoryFlag(selectedChoice.storyFlagToSet);
        }

        // Cek apakah ada event lanjutan langsung (Immediate Branching)
        if (selectedChoice.haveDialogeAfterChoice)
        {
            foreach (var line in selectedChoice.dialogueAfterChoice)
            {
                dialogueQueue.Enqueue(line);
            }
            dialoguePanel.SetActive(true); // Tampilkan kembali panel dialog
            DisplayNextLine(); // Tampilkan dialog berikutnya
        }
        else
        {
            // Jika tidak ada, lanjutkan alur game seperti biasa
            GameManager.Instance.ProgressTime();
        }
    }
}