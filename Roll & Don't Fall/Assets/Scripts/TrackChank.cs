using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackChank
{
    private Vector3[] _basePoints;

    public Vector3[] BasePoints => _basePoints;

    private int _sigmentNumbers = 12;

    public void FormChank()
    {
        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();
        List<Vector2> uv = new List<Vector2>();

        Vector3 firstPrevPoint = _basePoints[0];
        Vector3 secondPrevPoint = new Vector3(_basePoints[0].x + 5, _basePoints[0].y, _basePoints[0].z);
    }
}
