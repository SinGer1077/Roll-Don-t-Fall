using System.Collections.Generic;

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
    private GameObject _objectWithForces;

    private Dictionary<IForce, bool> _forces;

    private bool _isMoving = false;   

    private float _direction_coef = 0.05f;

    private Vector2 _moveDirection;

    private float _maxSpeed = 10f;

    private void Awake()
    {
        _forces = new Dictionary<IForce, bool>();
        var forcesComponents = _objectWithForces.GetComponents<IForce>();
        foreach (var component in forcesComponents)
        {
            _forces.Add(component, true);
        }
    }

    private void Update()
    {
        if (_isMoving)
        {
            _moveDirection = _playerInput.actions["Move"].ReadValue<Vector2>();
            MoveBody();
        }
        
        foreach (var force in _forces)
        {
            if (force.Value == true)
                force.Key.DoForce();
        }
        
    }

    public void StartMoveBody(BaseEventData eventData)
    {
        _isMoving = true;
    }

    public void EndMoveBody(BaseEventData eventData)
    {
        _isMoving = false;
    }

    private void MoveBody()
    {
        float xSpeed = _body.velocity.x + _moveDirection.x * _direction_coef;
        float zSpeed = _body.velocity.z + _moveDirection.y * _direction_coef;
        if (Mathf.Abs(xSpeed) > _maxSpeed || Mathf.Abs(zSpeed) > _maxSpeed)
        {
            return;
        }
        
        _body.velocity = new Vector3(xSpeed,
            _body.velocity.y,
            zSpeed);
    }        
}
