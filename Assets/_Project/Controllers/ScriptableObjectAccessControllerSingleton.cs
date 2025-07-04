using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton instance of BattleController. It should persist between scenes.
/// It holds references to all necessary instances of objects from the scenes related to Battle Phase.
/// </summary>
public class ScriptableObjectAccessControllerSingleton : MonoBehaviour
{
    public static ScriptableObjectAccessControllerSingleton Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }


    [SerializeField]
    private PlaythroughCommonFlagsSO _commonFlags;

    public PlaythroughCommonFlagsSO CommonFlags { get => _commonFlags; }

}