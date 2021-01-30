using System;
using AndromedaCore.LevelManagement;
using UnityEngine;

public class MaskManager : MonoBehaviour
{
    private static MaskType _mask = MaskType.Default;

    [SerializeField] private Sprite owlSprite;
    [SerializeField] private Sprite monkeySprite;
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Sprite selfSprite;
    [SerializeField] private Sprite tigerSprite;

    private SpriteRenderer _renderer;

    void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        WorldBroadcast.MaskChanged.Subscribe(OnMaskChanged);
    }

    private void OnDestroy()
    {
        WorldBroadcast.MaskChanged.Unsubscribe(OnMaskChanged);
    }

    private void Start()
    {
        SetSprite(_mask);
    }

    private void OnMaskChanged(MaskType mt)
    {
        SetMask(mt);
    }

    private void SetMask(MaskType maskType)
    {
        print("Set Mask from " + _mask + " to: " + maskType);
        _mask = maskType;
        SetSprite(maskType);
        
    }

    private void SetSprite(MaskType maskType)
    {
        switch (maskType)
        {
            case MaskType.Self:
                _renderer.sprite = selfSprite;
                break;
            case MaskType.Default:
                _renderer.sprite = defaultSprite;
                break;
            case MaskType.Owl:
                _renderer.sprite = owlSprite;
                break;
            case MaskType.Monkey:
                _renderer.sprite = monkeySprite;
                break;
            case MaskType.Tiger:
                _renderer.sprite = tigerSprite;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}

public enum MaskType
{
    Self,
    Default,
    Owl,
    Monkey,
    Tiger
}
