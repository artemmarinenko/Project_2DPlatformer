using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyOnPlayer : MonoBehaviour
{
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
        _spriteRenderer.sprite = null;
        _position = GetComponent<Transform>().localPosition;


        GameEvent.onPlayerFlip += FlipHandler;
        GameEvent.onGetKey += KeyGetHandler;
        GameEvent.onDoorOpened += DoorOpenedHandler;


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

    private void KeyGetHandler(DoorsKeySystem.Colors color)
    {
        SetKeyColor(color, _spriteRenderer);
        GetComponentInParent<Player>().SetKeyStatus(true);

    }

    private void DoorOpenedHandler(DoorsKeySystem.Colors color)
    {
        if(color == _keyColor)
            _spriteRenderer.sprite = null;
    }



    public void FlipHandler(bool flip)
    {
        
        _spriteRenderer.flipX = flip;
        if (flip)
            transform.localPosition = new Vector2(-_position.x,_position.y);
        else
            transform.localPosition = _position;
    }
    


}
