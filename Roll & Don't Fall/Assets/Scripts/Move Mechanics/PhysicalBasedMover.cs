using UnityEngine;

public class PhysicalBasedMover : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _body;

    [SerializeField]
    private float _acceleration;

    private float x_speed;

    private float y_speed;

    private float z_speed;

    public void MoveBody(Vector2 moveDirection)
    {
        x_speed += moveDirection.x;
        z_speed += moveDirection.y;
        _body.velocity = new Vector3(x_speed * _acceleration, _body.velocity.y, z_speed * _acceleration);
    }
}
