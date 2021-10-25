using System.Collections;

using UnityEngine;

public class ControllerMover : MonoBehaviour
{
    [SerializeField]
    private RectTransform _draggedRect;

    [SerializeField]
    private RectTransform _parentRect;

    [SerializeField]
    private EllipseInsideEllipseChecker _checker;

    [SerializeField]
    private PhysicalBasedMover _characterMover;    

    private Vector2 _lastPosition;

    public void SetLastPosition()
    {
        _lastPosition = _draggedRect.position;
    }

    public void Move(Vector2 eventDataPosition)
    {
        if (_checker.CheckEllipseInside(eventDataPosition))
        {
            SetLastPosition();
            _draggedRect.position = eventDataPosition;

            Vector2 difference = eventDataPosition - _lastPosition;            
            _characterMover.MoveBody(difference);
        }
    }
}
