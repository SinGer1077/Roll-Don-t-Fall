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

    private Mesh _mesh;

    private void Start()
    {
        CreateMesh();

        GameObject gameObject = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));
        gameObject.GetComponent<MeshFilter>().mesh = _mesh;
    }

    private void OnDrawGizmos()
    {
        
    }

    private void Update()
    {
        transform.position = Bezier.GetPoint(p0.position, p1.position, p2.position, p3.position, time);
    }    

    private void CreateMesh()
    {
        _mesh = new Mesh();

        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();
        List<Vector2> uv = new List<Vector2>();

        int sigmentNumber = 12;
        Vector3 previousPoint = p0.position;
        Vector3 secondPrevPoint = new Vector3(p0.position.x + 5, p0.position.y, p0.position.z);
             

        for (int i = 0; i < sigmentNumber; i++)
        {
            float parameter = (float)i / sigmentNumber;
            Vector3 point = Bezier.GetPoint(p0.position, p1.position, p2.position, p3.position, parameter);
            Vector3 secondPoint = new Vector3(point.x + 5, point.y, point.z);

            vertices.Add(point);
            vertices.Add(secondPoint);
            uv.Add(point);
            uv.Add(secondPoint);

            previousPoint = point;
            secondPrevPoint = secondPoint;               
        }      
        
        for (int i = 0; i < vertices.Count - 2; i++)
        {
            triangles.Add(i);
            triangles.Add(i + 1);
            triangles.Add(i + 2);
        }

        _mesh.vertices = vertices.ToArray();
        _mesh.uv = uv.ToArray();
        _mesh.triangles = triangles.ToArray();

        Debug.Log(triangles.Count);

        _mesh.RecalculateNormals();
    }
}
