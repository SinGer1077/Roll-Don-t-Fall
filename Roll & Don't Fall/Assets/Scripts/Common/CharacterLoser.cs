using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLoser : MonoBehaviour
{
    private float _timeToLose = 3f;

    private float _timer = 0f;

    private bool _isUntouch = false;

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Track")
        {
            _isUntouch = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Track")
        {
            _isUntouch = false;
            _timer = 0;
        }
    }

    private void Update()
    {
        if (_isUntouch)
        {
            _timer += Time.deltaTime;
            if (_timer >= _timeToLose)
            {
                Time.timeScale = 0;
            }
        }
    }
}
