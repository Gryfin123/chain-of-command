using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton instance of GameController. It should persist between scenes.
/// It holds references to all necessary instances of objects from the scenes related to initial Game States.
/// </summary>
public class GameControllerSingleton : MonoBehaviour
{
    public static GameControllerSingleton Instance { get; private set; }
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
    public Canvas mainMenuPhaseCanvas;

    public void ShowMainMenuCanvas()
    {
        mainMenuPhaseCanvas.gameObject.SetActive(true);
    }
    public void HideMainMenuCanvas()
    {
        mainMenuPhaseCanvas.gameObject.SetActive(false);
    }
}
