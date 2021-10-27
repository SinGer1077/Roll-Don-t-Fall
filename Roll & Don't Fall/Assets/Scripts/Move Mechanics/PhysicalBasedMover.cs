using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PhysicalBasedMover : MonoBehaviour
{
    [SerializeField]
    private PlayerInput _playerInput;

    [SerializeField]
    private Rigidbody _body;

    private bool _isMoving = false;

    private float _direction_coef = 0.01f;

    private Vector2 _moveDirection;

    private float x_speed;

    private float y_speed;

    private float z_speed;

    public void StartMoveBody(BaseEventData eventData)
    {
        _isMoving = true;
        Debug.Log("Begin Drag");
    }

    public void EndMoveBody(BaseEventData eventData)
    {
        _isMoving = false;
        SmoothStopBody();
        Debug.Log("End Drag");
    }

    private void Update()
    {
        if (_isMoving)
        {
            _moveDirection = _playerInput.actions["Move"].ReadValue<Vector2>();
            MoveBody();
        }
    }

    private void MoveBody()
    {    
        x_speed += _moveDirection.x * _direction_coef;
        z_speed += _moveDirection.y * _direction_coef;
        
        _body.velocity = new Vector3(x_speed, _body.velocity.y, z_speed);
        Debug.Log(_body.velocity);
    }

    private void SmoothStopBody()
    {
        _body.velocity = Vector3.Lerp(new Vector3(0, _body.velocity.y, 0), _body.velocity, 0);
    }


    
}
