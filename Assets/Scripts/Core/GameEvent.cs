using System;
using System.Collections;
using System.Collections.Generic;
using TimeControll;
using UnityEngine;

public static class GameEvent 
{
    public delegate void DoorsAndKeys(DoorsKeySystem.Colors color);
    public static event DoorsAndKeys onGetKey;
    public static event DoorsAndKeys onDoorOpened;

    public delegate void PlayerFlips(bool flip);
    public static event PlayerFlips onPlayerFlip;


    public delegate void  DealDamage();
    public static event DealDamage onPlayerDamageDone;

    public delegate void DealDamageZombie(Collider2D zombie);
    public static event DealDamageZombie onZombieDamageDone;


    public delegate void isRewinding();
    public static event isRewinding onRewindEvent;

    public static event isRewinding onRecordEvent;

    public delegate void Finish();
    public static event Finish onFinish;

    public static void RaiseOnFinish()
    {
        onFinish?.Invoke();
    }

    public static void RaiseOnDoorOpened(DoorsKeySystem.Colors color)
    {
        onDoorOpened?.Invoke(color);
    }
    public static void RaiseOnKeyGet(DoorsKeySystem.Colors color)
    {
        onGetKey?.Invoke(color);
    }

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

    public static void RaiseOnPlayerFlips(bool flip)
    {
        onPlayerFlip?.Invoke(flip);
    }

}
