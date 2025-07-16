using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableCommand : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Canvas canvas;
    [SerializeField]
    private GlobalFlagsSO commonFlags;

    /// <summary>
    /// Parent where drag begin
    /// </summary>
    private Transform _originalParent;
    /// <summary>
    /// Parent where command has to go to when drag ends
    /// </summary>
    [HideInInspector]
    public Transform parentAfterDrag;

    private RectTransform _rectTransform;
    private Image _image;

    /// <summary>
    /// Initial click on command decides if command can be dragged. This is set to true if it is possible.
    /// </summary>
    private bool _canBeDragged = true;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (commonFlags.CanMoveCommandsBetweenSlots)
        {
            _canBeDragged = true;
            parentAfterDrag = transform.parent;
            _originalParent = transform.parent;
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

            if (_originalParent != parentAfterDrag)
            {
                var movedCommand = GetComponent<CommandDisplay>();
                _originalParent.GetComponent<CommandSlot>().CommandMovedOut(movedCommand);
                parentAfterDrag.GetComponent<CommandSlot>().CommandMovedIn(movedCommand);
            }
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
