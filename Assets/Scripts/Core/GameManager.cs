// Scripts/Core/GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Tooltip("Urutan event dari Hari 1 Siang, Hari 1 Malam, Hari 2 Siang, dst.")]
    [SerializeField] private DialogueEventSO[] gameTimeline;

    private int currentTimeIndex = -1;
    public int CurrentDay { get; private set; }
    public bool IsNight { get; private set; }

    // Referensi ke sistem lain
    private DialogueManager dialogueManager;

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
        }
    }

    private void Start()
    {
        // Cari referensi saat game dimulai
        dialogueManager = FindObjectOfType<DialogueManager>();
        StartGame();
    }

    public void StartGame()
    {
        Debug.Log("Game Started!");
        currentTimeIndex = -1;
        // Kita langsung mulai event pertama
        ProgressTime();
    }

    // Ini adalah inti dari game loop
    public void ProgressTime()
    {
        currentTimeIndex++;

        if (currentTimeIndex >= gameTimeline.Length)
        {
            Debug.Log("GAME FINISHED! (Ending sequence would start here)");
            // Nanti di sini kita panggil EndingManager
            return;
        }

        // Hitung hari dan waktu
        CurrentDay = (currentTimeIndex / 2) + 1;
        IsNight = (currentTimeIndex % 2) != 0;

        Debug.Log($"--- Starting Day {CurrentDay}, {(IsNight ? "Night" : "Day")} ---");

        // Mulai event berikutnya di timeline
        dialogueManager.StartDialogue(gameTimeline[currentTimeIndex]);
    }
}