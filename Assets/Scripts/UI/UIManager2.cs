using System;
using UnityEngine;

public class UIManager2 : MonoBehaviour {
    #region Callbacks
    public Action<int> OnChoiceSelected;

    #endregion
    
    #region RuntimeData
    private UIChoiceSelector _uiChoiceSelector;
    #endregion
    
    public void Initialization() {
        _uiChoiceSelector = GetComponentInChildren<UIChoiceSelector>();
        _uiChoiceSelector.OnChoiceSelected += i => OnChoiceSelected.Invoke(i);
    }
    
    public void DisplayChoices(ChoiceData[] choices) {
        _uiChoiceSelector.DisplayChoices(choices);
    }

    public void ClearChoices() {
        _uiChoiceSelector.ClearChoices();
    }
}
