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

    private bool _toTheUp;

    public void SetDifficultCount()
    {
        DifficultLevelController controller = FindObjectOfType<DifficultLevelController>();
        _difficultCount = controller.CurrentDifficultLevel;
    }

    private void Start()
    {
        SetDifficultCount();
        _downPosition = new Vector3(transform.position.x, transform.position.y - (_difficultCount + 1), transform.position.z);
        _upPosition = new Vector3(transform.position.x, transform.position.y + (_difficultCount + 1), transform.position.z);

        _startTime = Time.time;
        _distance = Vector3.Distance(_downPosition, _upPosition);

        _toTheUp = true;
    }

    private void Update()
    {        
        float distCovered = (Time.time - _startTime) * _difficultCount;
        float fractionOfJourney = distCovered / _distance;

        if (_toTheUp == true)
        {
            transform.position = Vector3.Lerp(_downPosition, _upPosition, fractionOfJourney);

            if (1.0f - fractionOfJourney < 0.1f)
            {
                _toTheUp = false;
            }
        }
        else
        {
            transform.position = Vector3.Lerp(_upPosition, _downPosition, fractionOfJourney);

            if (1.0f - fractionOfJourney < 0.1f)
            {
                _toTheUp = true;
            }
        }
    }
}
