using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Dragger : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private UnityEvent _dragBeginning;

    [SerializeField]
    private UnityEvent _dragging;

    [SerializeField]
    private UnityEvent _dragEnding;

    private Vector2 lastMousePosition;

    private RectTransform _draggedRect;

    private void Start()
    {
        _draggedRect = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {        
        Debug.Log("begin dragging");
        lastMousePosition = eventData.position;
        _dragBeginning?.Invoke();
    }    

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentMousePosition = eventData.position;
        Vector2 diff = currentMousePosition - lastMousePosition;        

        Vector3 newPosition = _draggedRect.position + new Vector3(diff.x, diff.y, transform.position.z);
        Vector3 oldPos = _draggedRect.position;

        _draggedRect.position = newPosition;        

        lastMousePosition = currentMousePosition;

        _dragging?.Invoke();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Drag end");
        _dragEnding?.Invoke();
    }
}
