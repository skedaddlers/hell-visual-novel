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
}

[CreateAssetMenu(fileName = "Dialogue Event", menuName = "Scriptable Objects/DialogueEvent")]
public class DialogueEventSO : ScriptableObject
{
    public List<DialogueLine> dialogueLines;
    public List<Choice> choices;
}