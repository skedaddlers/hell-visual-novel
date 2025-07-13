using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIChoiceItem : MonoBehaviour, IPointerClickHandler {
    public Action OnChoiceSelected;
    
    [SerializeField] private TextMeshProUGUI choiceText;
    
    public void SetChoiceData(ChoiceData choiceData) {
        choiceText.text = $"[{choiceData.choiceIndex}] {choiceData.choiceText}";
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (eventData.button == PointerEventData.InputButton.Left) {
            OnChoiceSelected?.Invoke();
        }
    }
}
