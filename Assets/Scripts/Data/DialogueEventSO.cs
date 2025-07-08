using UnityEngine;
using System;
using System.Collections.Generic;

public enum StatType
{
    Charm,
    Intelligence,
    Energy
}

[Serializable]
public struct DialogueLine
{
    public CharacterSO character;
    [TextArea(3, 10)]
    public string line;
    public bool isFinalLine; // Apakah ini adalah dialog terakhir dalam event
}

[Serializable]
public struct StatChange
{
    public StatType statToChange;
    public int amount;
}

[Serializable]
public struct Choice
{
    [TextArea(3, 10)]
    public string choiceText;
    public List<StatChange> statChanges;

    public bool haveDialogeAfterChoice; // Apakah ada dialog setelah pilihan ini
    public List<DialogueLine> dialogueAfterChoice; // Dialog yang akan ditampilkan setelah pilihan ini

    [Tooltip("Event flag yang akan disimpan untuk mempengaruhi event-event berikutnya. Kosongkan jika tidak ingin menyimpan flag.")]
    public string storyFlagToSet;
}

[CreateAssetMenu(fileName = "Dialogue Event", menuName = "Scriptable Objects/DialogueEvent")]
public class DialogueEventSO : ScriptableObject
{
    public List<DialogueLine> dialogueLines;
    public List<Choice> choices;

}