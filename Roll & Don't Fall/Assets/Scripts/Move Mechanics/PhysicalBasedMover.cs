using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PhysicalBasedMover : MonoBehaviour
{
    [SerializeField]
    private PlayerInput _playerInput;

    [SerializeField]
    private Rigidbody _body;

    [SerializeField]
    private SmoothStop _stopper;

    private bool _isMoving = false;   

    private float _direction_coef = 0.01f;

    private Vector2 _moveDirection;

    private float x_speed;

    private float y_speed;

    private float z_speed;   

    public void StartMoveBody(BaseEventData eventData)
    {
        _isMoving = true;        
    }

    public void EndMoveBody(BaseEventData eventData)
    {
        _isMoving = false;           
    }

    private void Update()
    {
        if (_isMoving)
        {
            _moveDirection = _playerInput.actions["Move"].ReadValue<Vector2>();
            MoveBody();
        }
        else
        {
            _stopper.SmoothStopping();
        }
    }

    private void MoveBody()
    {    
        x_speed += _moveDirection.x * _direction_coef;
        z_speed += _moveDirection.y * _direction_coef;
        
        _body.velocity = new Vector3(_body.velocity.x + _moveDirection.x * _direction_coef,
            _body.velocity.y,
            _body.velocity.z + _moveDirection.y * _direction_coef);       
    }    
}
