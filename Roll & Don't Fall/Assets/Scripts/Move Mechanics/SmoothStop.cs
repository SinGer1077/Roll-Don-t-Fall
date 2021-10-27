using UnityEngine;

public class SmoothStop : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _body;

    private float _speed = 1.0f;

    private Vector3 _startMarker;

    private Vector3 _velocity;

    private void Start()
    {        
        _velocity = Vector3.zero;

        _startMarker = new Vector3(0, _body.velocity.y, 0);        
    }

    public void SmoothStopping()
    {
        _speed = Mathf.Max(Mathf.Abs(_body.velocity.x), Mathf.Abs(_body.velocity.z));
        _body.velocity = Vector3.SmoothDamp(_body.velocity, _startMarker, ref _velocity, _speed);
    }
}
