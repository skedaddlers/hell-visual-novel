using System;
using UnityEngine;

public class UIChoiceSelector : MonoBehaviour
{
    public Action<int> OnChoiceSelected;
    
    [SerializeField] private UIChoiceItem choiceItemPrefab;
    [SerializeField] private RectTransform choiceContainer;

    public void DisplayChoices(ChoiceData[] choices) {
        ClearChoices();
        
        for (var i = 0; i < choices.Length; i++) { 
            var choiceItem = Instantiate(choiceItemPrefab, choiceContainer);
            choiceItem.SetChoiceData(choices[i]);
            var index = i;
            choiceItem.OnChoiceSelected += () => OnChoiceSelected?.Invoke(index);
        }
    }
    
    public void ClearChoices() {
        foreach (Transform child in choiceContainer) {
            Destroy(child.gameObject);
        }
    }
}
