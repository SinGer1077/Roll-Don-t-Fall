using UnityEngine;

public class PhysicalBasedMover : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _body;

    private float _direction_coef = 0.02f;

    private float x_speed;

    private float y_speed;

    private float z_speed;

    public void MoveBody(Vector2 moveDirection)
    {    
        x_speed += moveDirection.x * _direction_coef;
        z_speed += moveDirection.y * _direction_coef;
        
        _body.velocity = new Vector3(x_speed, _body.velocity.y, z_speed);
        Debug.Log(_body.velocity);
    }
    
}
