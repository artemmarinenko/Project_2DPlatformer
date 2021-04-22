﻿using System;
using System.Collections;
using System.Collections.Generic;
using TimeControll;
using UnityEngine;

public static class GameEvent 
{
    public delegate void  DealDamage();
    public static event DealDamage onPlayerDamageDone;

    public delegate void DealDamageZombie(Collider2D zombie);
    public static event DealDamageZombie onZombieDamageDone;


    public delegate void isRewinding();
    public static event isRewinding onRewindEvent;

    public static event isRewinding onRecordEvent;

    

    public static void RaiseOnPlayerDamageDone()
    {
        onPlayerDamageDone?.Invoke();
    }

    public static void RaiseOnRewind()
    {
        onRewindEvent?.Invoke();
    }

    public static void RaiseOnRecord()
    {
        onRecordEvent?.Invoke();
    }

    public static void RaiseOnZombieDamageDone(Collider2D zombie)
    {
        onZombieDamageDone?.Invoke(zombie);
    }

}
