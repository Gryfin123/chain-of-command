using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Class resposible for processing command data for player to use. It is not supposed
// to process any Effect logic. This is responsibility of CommandEffectProcessor
public class CommandController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public CommandDataSO data;

    [SerializeField] private TextMeshProUGUI labelName;
    [SerializeField] private TextMeshProUGUI labelDescription;
    [SerializeField] private GameObject   panelDescription;
    [SerializeField] private TextMeshProUGUI labelCost;
    [SerializeField] private Image imageComponent;

    public void Init()
    {

    }

    private void Start()
    {
        UpdateVisual();
    }

    public void UpdateVisual()
    {
        labelName.text = data.commandName;
        labelDescription.text = data.GetProcessedDescription();
        labelCost.text = data.cost.ToString();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse entered. Showing Description");
        if (panelDescription != null)
        {
            panelDescription.SetActive(true);
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse Exit. Hiding Description");
        if (panelDescription != null)
        {
            panelDescription.SetActive(false);
        }
    }
}
