using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SpriteState : MonoBehaviour
{
    [SerializeField]
    protected int _state = 0;

    [SerializeField] protected UnityEvent onStageChanged;

    public virtual int State
    {
        get
        {
            return _state;
        }
        set
        {
            if (_state != value) {
                onStageChanged?.Invoke();
            }
            _state = value;
            RefreshUI();
        }
    }

    public int StateCount
    {
        get
        {
            return sprites.Count;
        }
    }

    public List<Sprite> sprites;

    public SpriteRenderer spriteRenderer;
    public Image image;

    private void OnEnable()
    {
        RefreshUI();
    }

    private void OnValidate()
    {
        RefreshUI();
    }
    public void RefreshUI()
    {
        var s = Mathf.Clamp(_state, 0, sprites.Count - 1);
        var sprite = sprites.Count > 0 ? sprites[s] : null;

        if (spriteRenderer)
        {
            spriteRenderer.sprite = sprite;
        }

        if (image)
        {
            image.sprite = sprite;
        }
    }

    public void SetLast()
    {
        State = StateCount - 1;
    }

    public void SetFirst()
    {
        State = 0;
    }

    public void SetLast(bool value) {
        if (value) {
            SetLast();
            return;
        } 
        SetFirst();
    }
    
    public void SetSprites(Sprite[] sprites)
    {
        this.sprites.Clear();
        this.sprites.AddRange(sprites);
        RefreshUI();
    }
}