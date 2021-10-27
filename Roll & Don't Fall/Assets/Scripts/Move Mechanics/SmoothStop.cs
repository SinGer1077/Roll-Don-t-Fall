using UnityEngine;

public class SmoothStop : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _body;

    private float _speed = 1.0f;

    private float _startTime;

    private float _journeyLength;

    private Vector3 _startMarker;

    private Vector3 _velocity;

    private void Start()
    {
        _startTime = Time.time;

        _velocity = Vector3.zero;

        _startMarker = new Vector3(0, _body.velocity.y, 0);

        _journeyLength = Vector3.Distance(_startMarker, _body.velocity);
    }

    public void SmoothStopping()
    {
        _body.velocity = Vector3.SmoothDamp(_body.velocity, _startMarker, ref _velocity, _speed);
    }
}
