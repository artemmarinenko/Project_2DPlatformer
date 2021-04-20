using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvent 
{
    public delegate void  DealDamage();
    public static event DealDamage OnPlayerKilledEvent;

    public static void RaiseOnPlayerKilled()
    {
        OnPlayerKilledEvent?.Invoke();
    }
}
