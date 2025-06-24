using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton instance of RunController. It should persist between scenes.
/// It holds references to all necessary instances of objects from the scenes related to game progression through main map.
/// </summary>
public class RunControllerSingleton : MonoBehaviour
{
    public static RunControllerSingleton Instance { get; private set; }
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
    public Canvas explorationPhaseCanvas;
    [SerializeField]
    private LoadoutSO _startingLoadout;
    [SerializeField]
    private PlayerProfileSO _playerProfile;

    public void InitializeRun()
    {
        // Load Starting Loadout into player profile.
        _playerProfile.LoadLoadout(_startingLoadout);
        explorationPhaseCanvas.gameObject.SetActive(true);
    }

    public void ShowMainMenuCanvas()
    {
        explorationPhaseCanvas.gameObject.SetActive(true);
    }
    public void HideMainMenuCanvas()
    {
        explorationPhaseCanvas.gameObject.SetActive(false);
    }
}
