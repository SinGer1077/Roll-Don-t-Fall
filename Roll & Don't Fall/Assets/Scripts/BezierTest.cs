using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierTest : MonoBehaviour
{
    public Transform p0;
    public Transform p1;
    public Transform p2;
    public Transform p3;

    public float t;

    private void OnDrawGizmos()
    {
        int sigmentNubmer = 20;
        Vector3 previousPoint = p0.position;

        for (int i =0; i<sigmentNubmer+1; i++)
        {
            float parameter = (float)i / sigmentNubmer;
            Vector3 point = Bezier.GetPoint(p0.position, p1.position, p2.position, p3.position, parameter);
            Gizmos.DrawLine(previousPoint, point);
            previousPoint = point;
        }
    }
}
