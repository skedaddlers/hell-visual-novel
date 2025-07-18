using Cysharp.Threading.Tasks;
using RS;
using UnityEngine.Events;

public class GameManager2 : Singleton<GameManager2>
{
    #region RuntimeData
    private UIManager2 _uiManager;
    private UnityEvent<int> _onChoiceSelected = new UnityEvent<int>();
    #endregion

    private void Start()
    {
        _uiManager = GetComponentInChildren<UIManager2>();
        _uiManager.Initialization();

        _uiManager.OnChoiceSelected += index =>
        {
            _onChoiceSelected.Invoke(index);
        };


    }

    public async UniTask<int> SetChoices(ChoiceData[] choices)
    {
        _uiManager.DisplayChoices(choices);
        // _uiManager.DisplayLocationChoices(choices);
        var selected = await _onChoiceSelected.OnInvokeAsync(this.GetCancellationTokenOnDestroy());
        _uiManager.ClearChoices();
        return selected;
    }
    
    public async UniTask<int> SetLocationChoicesViaMap() {
        return await _uiManager.DisplayLocationMap();
    }
}
