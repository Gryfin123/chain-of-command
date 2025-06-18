using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton instance of RunController. It should persist between scenes.
/// It controls everything related to the current run, like current loadout or progress status.
/// </summary>
public class RunController : MonoBehaviour
{
    public static RunController Instance { get; private set; }
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
    private LoadoutSO startingLoadout;
    [SerializeField]
    private PlayerProfileSO playerProfile;

    public void StartRun()
    {
        // Load Starting Loadout into player profile.
        playerProfile.LoadLoadout(startingLoadout);
    }

    public void StartBattlePhase()
    {
        // Send data to BattleController
        BattleController.Instance.InitiateBattle();
    }

}
