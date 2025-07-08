using UnityEngine;
using System;
using System.Collections.Generic;
using TMPro; 

public class StatsDisplayUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI charmText;
    [SerializeField] private TextMeshProUGUI intelligenceText;
    [SerializeField] private TextMeshProUGUI energyText;

    void Start()
    {
        // Mendaftarkan diri sebagai observer untuk perubahan stat
        StatsManager.Instance.OnStatUpdated += UpdateStatsDisplay;
        UpdateStatsDisplay(StatType.Charm, 0); // Inisialisasi tampilan dengan nilai awal
        UpdateStatsDisplay(StatType.Intelligence, 0);
        UpdateStatsDisplay(StatType.Energy, 0);
    }

    private void UpdateStatsDisplay(StatType statType, int newValue)
    {
        // Update tampilan UI sesuai dengan perubahan stat
        Debug.Log($"Stat {statType} updated to {newValue}");
        string statText = $"{statType}: {newValue}";
        switch (statType)
        {
            case StatType.Charm:
                charmText.text = statText;
                break;
            case StatType.Intelligence:
                intelligenceText.text = statText;
                break;
            case StatType.Energy:
                energyText.text = statText;
                break;
        }
    }
}