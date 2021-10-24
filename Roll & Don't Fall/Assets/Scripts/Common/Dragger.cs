using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Dragger : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private ControllerMover _mover;

    [SerializeField]
    private UnityEvent _dragBeginning;

    [SerializeField]
    private UnityEvent _dragging;

    [SerializeField]
    private UnityEvent _dragEnding;

    public void OnBeginDrag(PointerEventData eventData)
    {
        _mover.SetLastPosition();
        _dragBeginning?.Invoke();
    }    

    public void OnDrag(PointerEventData eventData)
    {
        _mover.Move(eventData.position);
        _dragging?.Invoke();
    }

    public void OnEndDrag(PointerEventData eventData)
    {        
        _dragEnding?.Invoke();
    }    
}
