using UnityEngine;

public class FrontBackUpdater : MonoBehaviour
{
    private Vector3 _frontPosition;

    private Vector3 _backPosition;

    private float _difficultCount;

    private float _roadLength;


    private float _startTime;

    private float _distance;

    private int _movementDirection = 0; //0 - stop, 1 - front, 2 - back 

    private float _randomSpeedForBlock;

    public void SetDifficultCount()
    {
        DifficultLevelController controller = FindObjectOfType<DifficultLevelController>();
        _difficultCount = controller.CurrentDifficultLevel;
    }

    public void SetRoadLength(float length)
    {
        _roadLength = length;
    }

    private void SetMoveDirection()
    {
        _startTime = Time.time;
        switch (_movementDirection)
        {
            case 0:
                _movementDirection = 1;
                break;
            case 1:
                _movementDirection = 2;
                break;
            case 2:
                _movementDirection = 1;
                break;
        }
    }

    private void Start()
    {
        SetDifficultCount();
        _frontPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + _roadLength);
        _backPosition = transform.position;

        _distance = Vector3.Distance(_frontPosition, _backPosition);
        _randomSpeedForBlock = Random.Range(1f, 3f);

        float timeToStart = Random.Range(0.0f, 1.0f);
        Invoke("SetMoveDirection", timeToStart);
    }

    private void Update()
    {
        float distCovered = (Time.time - _startTime) * _difficultCount * _randomSpeedForBlock;
        float fractionOfJourney = distCovered / _distance;

        if (_movementDirection == 1)
        {
            transform.position = Vector3.Lerp(_backPosition, _frontPosition, fractionOfJourney);

            if (1.0f - fractionOfJourney < 0.001f)
            {
                SetMoveDirection();
            }
        }
        else
        {
            transform.position = Vector3.Lerp(_frontPosition, _backPosition, fractionOfJourney);

            if (1.0f - fractionOfJourney < 0.001f)
            {
                SetMoveDirection();
            }
        }
    }
}
