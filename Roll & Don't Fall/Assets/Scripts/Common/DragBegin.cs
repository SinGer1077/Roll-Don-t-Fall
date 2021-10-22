using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DragBegin : MonoBehaviour, IBeginDragHandler
{
    [SerializeField]
    private UnityEvent _dragBeginning;

    public void OnBeginDrag(PointerEventData eventData)
    {
        _dragBeginning?.Invoke();
        Debug.Log(eventData.position);
    }
}
