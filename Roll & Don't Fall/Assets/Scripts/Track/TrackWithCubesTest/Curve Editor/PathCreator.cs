using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCreator : MonoBehaviour
{
    [HideInInspector]
    public Path path;

    public void CreatePath(Vector3 startPoint)
    {
        path = new Path(startPoint);
    }

    private void Awake()
    {
        //CreatePath(transform.position);
    }
}
