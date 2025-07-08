// Scripts/Data/TimelineNodeSO.cs
using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
public struct BranchCondition
{
    public string requiredFlag; // Flag yang dibutuhkan untuk cabang ini
    public DialogueEventSO eventToPlay; // Event yang akan dimainkan jika flag terpenuhi
}

[CreateAssetMenu(fileName = "Timeline Node", menuName = "Scriptable Objects/Timeline Node")]
public class TimelineNodeSO : ScriptableObject
{
    [Tooltip("Event yang akan dimainkan jika tidak ada kondisi cabang yang terpenuhi.")]
    public DialogueEventSO defaultEvent;

    [Tooltip("Daftar cabang. Akan dievaluasi dari atas ke bawah.")]
    public List<BranchCondition> conditionalBranches;
}