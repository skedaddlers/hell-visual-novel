using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    public Button quitButton;
    public Button settingsButton;
    public GameObject settingsPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        settingsPanel.SetActive(false);

        quitButton.onClick.AddListener(QuitGame);
        settingsButton.onClick.AddListener(ToggleSettingsPanel);
    }

    void QuitGame()
    {
        Application.Quit();
    }

    void ToggleSettingsPanel()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
