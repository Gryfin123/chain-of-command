using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This scriptable object is supposed to keep the flags that are used, but not managed by the player
/// /// </summary>
public class GlobalFlagsSO : ScriptableObject
{
    [SerializeField]
    private bool _canMoveCommandsBetweenSlots = true;

    /// <summary>
    /// When true, player can move Commands between different slots (inside storage or between storage and chain).
    /// </summary>
    public bool CanMoveCommandsBetweenSlots 
    { 
        get => _canMoveCommandsBetweenSlots; 
        set => _canMoveCommandsBetweenSlots = value; 
    }
}
