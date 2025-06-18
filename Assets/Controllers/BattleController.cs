using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton instance of BattleController. It should persist between scenes.
/// After battle starts, this will manage what is the setup chosen by player and start the execution of it.
/// </summary>
public class BattleController : MonoBehaviour
{
    [SerializeField] private OpponentDataSO opponentProfile;
    [SerializeField] private PlayerProfileSO playerProfile;

    [SerializeField] private GameObject opponentDisplay;
    [SerializeField] private GameObject playerDisplay;
    [SerializeField] private GameObject chainDisplay;

    [SerializeField] private GameObject commandPrefab;
    [SerializeField] private List<GameObject> playerStorageSlots;
    [SerializeField] private List<GameObject> playerChainSlots;

    public static BattleController Instance { get; private set; }
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

    public void InitiateBattle()
    {
        // Load Commands Into Storage UI
        RefreshCommandSlots();

        // Show UI
        opponentDisplay.SetActive(true);
        chainDisplay.SetActive(true);
    }

    public void FinishBattle()
    {
        // Clear Prefabs from Chain and Put them back in Storage
        RefreshCommandSlots();

        opponentDisplay.SetActive(false);
        chainDisplay.SetActive(false);
    }

    private void RefreshCommandSlots()
    {
        // Remove Command Prefabs From Storage Slots.
        foreach (var slot in playerStorageSlots)
        {
            while (slot.transform.childCount > 0)
            {
                DestroyImmediate(slot.transform.GetChild(0).gameObject);
            }
        }

        // Load data from Player Profiole into Storage Display
        for (int i = 0; i < playerProfile.CommandList.Count; i++)
        {
            // If there is no more space to put commands into, stop it.
            if (i > playerProfile.StorageCapacity)
            {
                break;
            }

            Vector3 spawnLocation = new Vector3(
                playerStorageSlots[i].transform.localPosition.x,
                playerStorageSlots[i].transform.localPosition.y,
                playerStorageSlots[i].transform.localPosition.z);

            GameObject instPrefab = Instantiate(commandPrefab, spawnLocation, Quaternion.identity);
            instPrefab.GetComponent<CommandDisplay>().data = playerProfile.CommandList[i];
            instPrefab.transform.SetParent(playerStorageSlots[i].transform);
            instPrefab.transform.localScale = new Vector3(1,1,1);
        }


        // Remove Command Prefabs From Chain Slots.
        foreach (var slot in playerChainSlots)
        {
            while (slot.transform.childCount > 0)
            {
                DestroyImmediate(slot.transform.GetChild(0).gameObject);
            }
        }
    }

}
