using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IResettableKey
{
    // Start is called before the first frame update
    [SerializeField] protected DoorsKeySystem.Colors _keyColor;
    [SerializeField] protected Sprite _yellowKey;
    [SerializeField] protected Sprite _greenKey;
    [SerializeField] protected Sprite _blueKey;
    [SerializeField] protected Sprite _redKey;
    [SerializeField] private BoxCollider2D _boxCollider;

    private Vector2 _startingPoint;
    private DoorsKeySystem.Colors _startingColor;



    public SpriteRenderer _spriteRenderer { get; set; }
    protected Collider2D _collider2DThatOverlaps;
    protected Vector2 _position;

    public DoorsKeySystem.Colors GetKeyColor()
    {
        return _keyColor;
    }

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _position = GetComponent<Transform>().position;
        _boxCollider = GetComponent<BoxCollider2D>();

        SetKeyColor(_keyColor, _spriteRenderer);
        SetStartState(_position, _keyColor);

    }

    public void SetKeyColor(DoorsKeySystem.Colors color, SpriteRenderer renderer)
    {
        _keyColor = color;
        switch (color)
        {
            case DoorsKeySystem.Colors.Yellow:
                renderer.sprite = _yellowKey;
                break;

            case DoorsKeySystem.Colors.Blue:
                renderer.sprite = _blueKey;
                break;

            case DoorsKeySystem.Colors.Green:
                renderer.sprite = _greenKey;
                break;

            case DoorsKeySystem.Colors.Red:
                renderer.sprite = _redKey;
                break;

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameEvent.RaiseOnKeyGet(_keyColor);
        _spriteRenderer.sprite = null;
        _boxCollider = null;
    }




    // Need add color information to reset
    #region IResettableKeyImplementation
    public void Reset(Key keyPrefab)
    {
        Destroy(this.gameObject);
        Key newKey = Instantiate(keyPrefab,GetStartState().Item1,Quaternion.identity);
        newKey.SetKeyColor(GetStartState().Item2,newKey._spriteRenderer);
    }

    public void SetStartState(Vector2 postion, DoorsKeySystem.Colors color)
    {
        _startingPoint = postion;
        _startingColor = color;
    }

    public Tuple<Vector2, DoorsKeySystem.Colors> GetStartState()
    {
        return Tuple.Create(_startingPoint, _startingColor);
    }
    #endregion
}
