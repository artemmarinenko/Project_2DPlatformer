using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected DoorsKeySystem.Colors _keyColor;
    [SerializeField] protected Sprite _yellowKey;
    [SerializeField] protected Sprite _greenKey;
    [SerializeField] protected Sprite _blueKey;
    [SerializeField] protected Sprite _redKey;
    [SerializeField] private BoxCollider2D _boxCollider;
    public SpriteRenderer _spriteRenderer { get; set; }
    protected Collider2D _collider2DThatOverlaps;
    protected Vector2 _position;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _position = GetComponent<Transform>().position;
        _boxCollider = GetComponent<BoxCollider2D>();

        SetKeyColor(_keyColor, _spriteRenderer);
        
    }

    public void SetKeyColor(DoorsKeySystem.Colors color,SpriteRenderer renderer)
    {
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

    // Update is called once per frame
    void Update()
    {
        
        

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");
        
        GameEvent.RaiseOnKeyGet(_keyColor);
        Destroy(this.gameObject);
    }

}
