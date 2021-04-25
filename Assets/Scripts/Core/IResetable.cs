using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IResettable
{
    void Reset();
    void SetStartPoint(Vector2 postion,bool flip);
    Tuple<Vector2, bool> GetStartPoint();
}

public interface IResettableKey
{
    void Reset(Key keyPrefab);
    void SetStartState(Vector2 postion, DoorsKeySystem.Colors flip);
    Tuple<Vector2, DoorsKeySystem.Colors> GetStartState();

}

public interface IResettableDoor
{
    void Reset(DoorsKeySystem.Door keyPrefab);
    void SetStartState(Vector2 postion, DoorsKeySystem.Colors flip);
    Tuple<Vector2, DoorsKeySystem.Colors> GetStartState();

}

