using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvent 
{
    public delegate void  DealDamage();
    public static event DealDamage OnPlayerDamageDone;

    public static void RaiseOnPlayerDamageDone()
    {
        OnPlayerDamageDone?.Invoke();
    }
}
