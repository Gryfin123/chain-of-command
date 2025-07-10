using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Class resposible for processing command data for player to use. It is not supposed
/// to process any Effect logic. This is responsibility of CommandEffectProcessor
/// </summary>
public class CommandDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Data")]
    public BaseCommand data;
    private Canvas canvas;

    [SerializeField] private Material brokenFontAsset;
    [SerializeField] private Material notBrokenFontAsset;


    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI labelName;
    [SerializeField] private TextMeshProUGUI labelDescription;
    [SerializeField] private TextMeshProUGUI labelCost;
    [SerializeField] private Image bannerComponent;
    [SerializeField] private Image borderComponent;
    [SerializeField] private Image SplashartComponent;
    [SerializeField] private Image BrokenCrackOverlay;

    [SerializeField] private GameObject panelDescription;
    [SerializeField] private RectTransform descriptionAnchorLeft;
    [SerializeField] private RectTransform descriptionAnchorRight;


    private void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        UpdateVisual();
    }

    public void UpdateVisual()
    {
        labelName.text = data.commandName;
        labelDescription.text = data.GetProcessedDescription();
        labelCost.text = data.properties[CommandPropertyID.COST].EffectiveValue.ToString();
        bannerComponent.sprite = data.banner;
        borderComponent.color = data.BannerColor;
        SplashartComponent.sprite = data.splashart;

        if (data.broken)
        {
            BrokenCrackOverlay.gameObject.SetActive(true);
            labelName.fontMaterial = brokenFontAsset;
        }
        else
        {
            BrokenCrackOverlay.gameObject.SetActive(false);
            labelName.fontMaterial = notBrokenFontAsset;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        UpdateDescriptionPosition();
        if (panelDescription != null)
        {
            panelDescription.SetActive(true);
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (panelDescription != null)
        {
            panelDescription.SetActive(false);
        }
    }

    /// <summary>
    /// Ensures that description is next to the command, in position dependand on distance to edge of the screen. For example, Description will show on left if close to right edge of screen.
    /// (This should prevent description from appearing outside of view)
    /// </summary>
    private void UpdateDescriptionPosition()
    {
        // Get the screen position of the UI element's center
        // This method is great for getting a screen position regardless of Canvas Render Mode
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(canvas.worldCamera, transform.position);

        // Get the center of the screen
        float screenCenter = Screen.width / 2f;

        if (screenPoint.x < screenCenter)
        {
            // Is on left side
            panelDescription.transform.position = descriptionAnchorRight.position;
        }
        else if (screenPoint.x > screenCenter)
        {
            // Is on right side
            panelDescription.transform.position = descriptionAnchorLeft.position;
        }
        else
        {
            // Is in the center
            // It's not important to move it in that case.
        }
    }
}
