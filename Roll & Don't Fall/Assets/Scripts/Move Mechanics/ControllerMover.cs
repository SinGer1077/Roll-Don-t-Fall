using UnityEngine;

public class ControllerMover : MonoBehaviour
{
    [SerializeField]
    private RectTransform _draggedRect;    

    [SerializeField]
    private EllipseInsideEllipseChecker _checker;

    [SerializeField]
    private PhysicalBasedMover _characterMover;

    [SerializeField]
    private Rigidbody _characterRigidBody;    

    public void Move(Vector2 eventDataPosition)
    {
        Debug.Log(eventDataPosition);
        if (_checker.CheckEllipseInside(eventDataPosition))
        {
            _draggedRect.position = eventDataPosition;
        }
    }
}
