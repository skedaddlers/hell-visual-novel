using System;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class UIManager2 : MonoBehaviour
{
    #region Callbacks
    public Action<int> OnChoiceSelected;

    #endregion

    #region RuntimeData
    private UIChoiceSelector _uiChoiceSelector;
    private UIMapSelector _uiMapSelector;
    #endregion

    public void Initialization()
    {
        _uiMapSelector = GetComponentInChildren<UIMapSelector>(true);
        _uiMapSelector.OnLocationSelected += i => OnChoiceSelected?.Invoke(i);

        _uiChoiceSelector = GetComponentInChildren<UIChoiceSelector>();
        _uiChoiceSelector.OnChoiceSelected += i => OnChoiceSelected.Invoke(i);
    }

    public void DisplayChoices(ChoiceData[] choices)
    {
        _uiChoiceSelector.DisplayChoices(choices);
    }

    public void ClearChoices()
    {
        _uiChoiceSelector.ClearChoices();
    }
    
    public async UniTask<int> DisplayLocationMap() {
        var tcs = new UniTaskCompletionSource<int>();
        
        _uiMapSelector.Show();
        _uiMapSelector.OnLocationSelected += index => {
            _uiMapSelector.Hide();
            tcs.TrySetResult(index);
        };

        return await tcs.Task;
    }

    // public void ClearChoices() {
    //     _uiMapSelector.ClearLocations();
    // }
}
