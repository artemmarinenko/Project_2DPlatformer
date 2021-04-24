﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyOnPlayer : Key
{
    
    


    void Awake()
    {
    
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = null;
        _position = GetComponent<Transform>().localPosition;
        GameEvent.onPlayerFlip += FlipHandler;
        GameEvent.onGetKey += KeyGetHandler;


    }

    private void Update()
    {
        
        
    }

    private void KeyGetHandler(DoorsKeySystem.Colors color)
    {
        SetKeyColor(color, _spriteRenderer);
        GetComponentInParent<Player>().SetKeyStatus(true);

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