using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RollDontFall.TrackModule;

public class TrackChankFiller
{
    private Vector3[] _basePoints;

    public Vector3[] BasePoints => _basePoints;

    private int _sigmentNumber = 25;

    private Vector3 _axisDistance = new Vector3(5f, 1f, 5f);

    public Vector3 AxisDistance => _axisDistance;

    private GameObject _parent;

    public TrackChankFiller(Vector3[] points)
    {
        _basePoints = points;        
    }

    public void FormChank()
    {
        Vector3 previousPoint = _basePoints[0];

        for (int i = 1; i < _sigmentNumber + 1; i++)
        {
            float parameter = (float)i / _sigmentNumber;
            Vector3 point = Bezier.GetPoint(_basePoints[0], _basePoints[1], _basePoints[2], _basePoints[3], parameter);            

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = previousPoint;
            cube.transform.localScale = new Vector3(_axisDistance.x, _axisDistance.y, _axisDistance.z);
            cube.transform.rotation = Quaternion.LookRotation(Bezier.GetFirstDerivetive(_basePoints[0], _basePoints[1], _basePoints[2], _basePoints[3], parameter));

            previousPoint = point;
        }
    }

    public void AddPropertiesToChank(GameObject parent)
    {

    }
}
