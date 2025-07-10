using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Canvas canvas;
    [SerializeField]
    private PlaythroughCommonFlagsSO commonFlags;

    [HideInInspector]
    public Transform parentAfterDrag;

    private RectTransform _rectTransform;
    private Image _image;

    private bool _canBeDragged = true;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (commonFlags.CanMoveCommandsBetweenSlots)
        {
            _canBeDragged = true;
            parentAfterDrag = transform.parent;
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
            _image.raycastTarget = false;
        }
        else
        {
            _canBeDragged = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_canBeDragged)
        {
            _rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_canBeDragged)
        {
            transform.SetParent(parentAfterDrag);
            _image.raycastTarget = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        _rectTransform = GetComponent<RectTransform>();
        _image = GetComponent<Image>();
    }
}
