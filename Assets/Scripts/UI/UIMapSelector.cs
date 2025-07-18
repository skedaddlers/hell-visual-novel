using System;
using UnityEngine;
using UnityEngine.UI;

public class UIMapSelector : MonoBehaviour
{
    public Action<int> OnLocationSelected;

    [SerializeField] private Button cryptButton;
    [SerializeField] private Button agencyButton;
    [SerializeField] private Button downtownButton;

    private void Awake() {
        cryptButton.onClick.AddListener(() => OnLocationSelected?.Invoke(0));
        agencyButton.onClick.AddListener(() => OnLocationSelected?.Invoke(1));
        downtownButton.onClick.AddListener(() => OnLocationSelected?.Invoke(2));
    }

    public void Show() {
        gameObject.SetActive(true);
    }

    public void Hide() {
        gameObject.SetActive(false);
    }
}
