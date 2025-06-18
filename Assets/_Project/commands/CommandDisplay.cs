using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Class resposible for processing command data for player to use. It is not supposed
/// to process any Effect logic. This is responsibility of CommandEffectProcessor
/// </summary>
public class CommandDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Command data;

    [SerializeField] private TextMeshProUGUI labelName;
    [SerializeField] private TextMeshProUGUI labelDescription;
    [SerializeField] private GameObject panelDescription;
    [SerializeField] private TextMeshProUGUI labelCost;
    [SerializeField] private Image bannerComponent;
    [SerializeField] private Image borderComponent;
    [SerializeField] private Image SplashartComponent;

    private void Start()
    {
        UpdateVisual();
    }

    public void UpdateVisual()
    {
        labelName.text = data.commandName;
        labelDescription.text = data.GetProcessedDescription();
        labelCost.text = data.cost.ToString();
        bannerComponent.sprite = data.banner;
        borderComponent.color = data.BannerColor;
        SplashartComponent.sprite = data.splashart;
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
