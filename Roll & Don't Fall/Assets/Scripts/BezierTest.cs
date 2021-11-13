using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class BezierTest : MonoBehaviour
{
    [SerializeField]
    private Transform p0;

    [SerializeField]
    private Transform p1;

    [SerializeField]
    private Transform p2;

    [SerializeField]
    private Transform p3;

    [SerializeField, Range(0, 1)]
    private float time;

    // Update is called once per frame
    void Update()
    {
        transform.position = Bezier.GetPoint(p0.position, p1.position, p2.position, p3.position, time);
    }
}
