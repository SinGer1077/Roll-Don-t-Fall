using UnityEngine;

public class PhysicalBasedMover : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _body;

    [SerializeField]
    private float _acceleration_coef;

    private float x_speed;

    private float y_speed;

    private float z_speed;

    public void MoveBody(Vector2 moveDirection, float power)
    {
        x_speed += moveDirection.x;
        z_speed += moveDirection.y;

        float acceleration = power * _acceleration_coef;
        _body.velocity = new Vector3(x_speed * acceleration, _body.velocity.y, z_speed * acceleration);
        Debug.Log(_body.velocity);
    }
}
