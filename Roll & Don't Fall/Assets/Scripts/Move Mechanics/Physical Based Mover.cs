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

    public void MoveBody()
    {

    }
}
