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

    void Start()
    {
        dialoguePanel.SetActive(false);
        choicesPanel.SetActive(false);
        dialogueQueue = new Queue<DialogueLine>();
    }

    public void StartDialogue(DialogueEventSO dialogueEvent)
    {
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
        if (dialogueQueue.Count == 0)
        {
            DisplayChoices();
            return;
        }

        DialogueLine currentLine = dialogueQueue.Dequeue();
        characterNameText.text = currentLine.character.characterName;
        dialogueText.text = currentLine.line;
    }

    private void DisplayChoices()
    {
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

        // Lanjutkan alur game
        GameManager.Instance.ProgressTime();
    }
}