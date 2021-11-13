using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PhysicalBasedMover : MonoBehaviour
{
    /// <summary>
    /// данные с геймпада, положение шарика
    /// </summary>
    [SerializeField]
    private PlayerInput _playerInput; 

    /// <summary>
    /// персонаж
    /// </summary>
    [SerializeField]
    private Rigidbody _body;

    /// <summary>
    /// какой тип передвижения будем использовать
    /// </summary>
    [SerializeField]
    private MovingType _movingType;    

    /// <summary>
    /// флаг, двигаемся ли мы в определенный момент
    /// </summary>
    private bool _isMoving = false;

    /// <summary>
    /// данные, полученные с геймпада
    /// </summary>
    private Vector2 _moveDirection;
 
    /// <summary>
    /// коэффициент ускорения для типа Acceleration
    /// </summary>
    private float _acceleraionCoef = 0.05f;

    /// <summary>
    /// коэффициент задания скорости для типа Fixed
    /// </summary>
    private float _fixedSpeedCoef = 3.5f;

    /// <summary>
    /// порог скорости для движения персонажа
    /// </summary>
    private float _maxSpeed = 10f;  

    private void FixedUpdate()
    {
        // если двигаемся
        if (_isMoving)
        {
            //получаем позицию геймпада
            _moveDirection = _playerInput.actions["Move"].ReadValue<Vector2>();
            Movement(_movingType);            
        }    
    }

    /// <summary>
    /// Установка флажка при начале движения. Вызывается при событии BeginDrag у геймпада
    /// </summary>
    /// <param name="eventData"></param>
    public void StartMoveBody(BaseEventData eventData)
    {
        _isMoving = true;
    }

    /// <summary>
    /// Установка флажка при конце движения. Вызывается при событии EndDrag у геймпада
    /// </summary>
    /// <param name="eventData"></param>
    public void EndMoveBody(BaseEventData eventData)
    {
        _isMoving = false;
    }

    /// <summary>
    /// Задание скорости в соответствии с выбранным типом движения
    /// </summary>
    /// <param name="movingType"></param>
    private void Movement(MovingType movingType)
    {
        float xSpeed = 0.0f;
        float zSpeed = 0.0f;

        if (_movingType == MovingType.Acceleration)
        {
            AccelerationMovement(out xSpeed, out zSpeed);
        }
        else if (_movingType == MovingType.Fixed)
        {
            FixedMovement(out xSpeed, out zSpeed);
        }

        if (Mathf.Abs(xSpeed) > _maxSpeed || Mathf.Abs(zSpeed) > _maxSpeed)
        {
            return;
        }

        _body.velocity = new Vector3(xSpeed,
            _body.velocity.y,
            zSpeed);
    }

    /// <summary>
    /// Задание движения с ускорением
    /// </summary>
    /// <param name="xSpeed"></param>
    /// <param name="zSpeed"></param>
    private void AccelerationMovement(out float xSpeed, out float zSpeed)
    {
        xSpeed = _body.velocity.x + _moveDirection.x * _acceleraionCoef;
        zSpeed = _body.velocity.z + _moveDirection.y * _acceleraionCoef;
        
    }    
    
    /// <summary>
    /// Задание движения с фиксированной скоростью
    /// </summary>
    /// <param name="xSpeed"></param>
    /// <param name="zSpeed"></param>
    private void FixedMovement(out float xSpeed, out float zSpeed)
    {
        xSpeed = _moveDirection.x * _fixedSpeedCoef;
        zSpeed = _moveDirection.y * _fixedSpeedCoef;       
    }  
}

/// <summary>
/// тип передвижения
/// </summary>
public enum MovingType
{
    /// <summary>
    /// передвижение с ускорением - значение позиции джойстика соответствует величине ускорения
    /// </summary>
    Acceleration,
    /// <summary>
    /// фиксированное передвижение - значение позиции джойстика соответствует определенному значению скорости
    /// </summary>
    Fixed 
}
