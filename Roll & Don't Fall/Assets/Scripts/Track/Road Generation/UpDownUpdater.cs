using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownUpdater : MonoBehaviour
{
    private Vector3 _downPosition;

    private Vector3 _upPosition;

    private float _difficultCount;


    private float _startTime;

    private float _distance;

    private int _movementDirection = 0; //0 - stop, 1 - up, 2 - down 

    private float _randomSpeedForBlock;

    public void SetDifficultCount()
    {
        DifficultLevelController controller = FindObjectOfType<DifficultLevelController>();
        _difficultCount = controller.CurrentDifficultLevel;
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
        _downPosition = new Vector3(transform.position.x, transform.position.y - (_difficultCount + 1), transform.position.z);
        _upPosition = new Vector3(transform.position.x, transform.position.y + (_difficultCount + 1), transform.position.z);
        
        _distance = Vector3.Distance(_downPosition, _upPosition);
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
            transform.position = Vector3.Lerp(_downPosition, _upPosition, fractionOfJourney);

            if (1.0f - fractionOfJourney < 0.001f)
            {
                SetMoveDirection();
            }
        }
        else
        {
            transform.position = Vector3.Lerp(_upPosition, _downPosition, fractionOfJourney);

            if (1.0f - fractionOfJourney < 0.001f)
            {
                SetMoveDirection();
            }
        }
    }
}
