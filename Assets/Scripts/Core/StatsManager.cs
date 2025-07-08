using System;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public static StatsManager Instance { get; private set; }

    private Dictionary<StatType, int> playerStats;
    // Nanti bisa ditambahkan: private Dictionary<CharacterSO, int> characterAffinities;

    // Ini adalah implementasi Observer Pattern!
    public event Action<StatType, int> OnStatUpdated;

    private void Awake()
    {
        // Singleton Pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeStats();
        }
    }

    private void InitializeStats()
    {
        playerStats = new Dictionary<StatType, int>();
        foreach (StatType stat in Enum.GetValues(typeof(StatType)))
        {
            playerStats.Add(stat, 0); // Semua stat mulai dari 0
        }
    }

    public int GetStat(StatType stat)
    {
        return playerStats.ContainsKey(stat) ? playerStats[stat] : 0;
    }

    public void ChangeStat(StatType stat, int amount)
    {
        if (playerStats.ContainsKey(stat))
        {
            playerStats[stat] += amount;
            Debug.Log($"Stat {stat} changed by {amount}. New value: {playerStats[stat]}");

            // Beri tahu semua 'observer' bahwa stat ini telah diperbarui
            OnStatUpdated?.Invoke(stat, playerStats[stat]);
        }
    }
}