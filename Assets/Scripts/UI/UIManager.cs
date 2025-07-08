using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public GameObject transitionPanel;
    public TextMeshProUGUI transitionText;
    public SpriteRenderer characterSpriteRenderer;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Menampilkan transisi antar timeslot selama 5 detik
    public void ShowTransition(string timeslot)
    {
        transitionPanel.SetActive(true);
        if(timeslot == "Ending")
        {
            transitionText.text = "THE END!";
            return;
        }
        transitionText.text = $"Day {GameManager.Instance.CurrentDay} - {timeslot}";
        Invoke("HideTransition", 5f); // Sembunyikan setelah 5 detik
    }

    public void ChangeCharacterSprite(CharacterSO character)
    {
        characterSpriteRenderer.sprite = character.characterSprite;
    }

    private void HideTransition()
    {
        transitionPanel.SetActive(false);
    }
    
}