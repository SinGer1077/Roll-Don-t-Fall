﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PathCreator))]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class RoadCreator : MonoBehaviour
{
    public float roadWidth = 3;

    [Range(.5f, 1.5f)]
    public float spacing = 1;

    public bool autoUpdate;

    public float tiling = 1;

    public void UpdateRoad()
    {
        Path path = GetComponent<PathCreator>().path;
        Vector3[] points = path.CalculateEvenlySpacedPoints(spacing);
        GetComponent<MeshFilter>().mesh = CreateRoadMesh(points, path.IsClosed());

        int textureRepeat = Mathf.RoundToInt(tiling * points.Length * spacing * 0.5f);
        //GetComponent<MeshRenderer>().sharedMaterial.mainTextureScale = new Vector2(1, textureRepeat);
    }

    Mesh CreateRoadMesh(Vector3[] points, bool isClosed)
    {
        Vector3[] verts = new Vector3[points.Length * 2];
        Vector2[] uvs = new Vector2[verts.Length];
        int numTris = 2 * (points.Length - 1) + ((isClosed) ? 2 : 0);
        int[] tris = new int[numTris * 3 * 4];
        int vertIndex = 0;
        int triIndex = 0;

        for (int i = 0; i < points.Length; i++)
        {
            Vector3 forward = Vector3.zero;

            if (i < points.Length - 1 || isClosed)
            {
                forward += points[(i + 1) % points.Length] - points[i];
            }

            if (i > 0 || isClosed)
            {
                forward += points[i] - points[(i - 1 + points.Length) % points.Length];
            }

            forward.Normalize();

            //Vector3 left = new Vector3(-forward.y, forward.x, forward.z);
            //Vector3 left = new Vector3(-forward.y, forward.z, forward.x);
            Vector3 left = new Vector3(-forward.z, forward.y, forward.x);

            verts[vertIndex] = points[i] + left * roadWidth * 0.5f;
            verts[vertIndex + 1] = points[i] - left * roadWidth * 0.5f;

            float completionPercent = i / (float)(points.Length - 1);
            float v = 1 - Mathf.Abs(2 * completionPercent - 1);

            uvs[vertIndex] = new Vector2(0, v);
            uvs[vertIndex + 1] = new Vector2(1, v);

            if (i < points.Length - 1 || isClosed)
            {
                tris[triIndex + 6] = vertIndex;
                tris[triIndex + 7] = (vertIndex + 2) % verts.Length;
                tris[triIndex + 8] = vertIndex + 1;

                tris[triIndex + 2] = vertIndex;
                tris[triIndex + 1] = (vertIndex + 2) % verts.Length;
                tris[triIndex] = vertIndex + 1;

                tris[triIndex + 11] = vertIndex + 1;
                tris[triIndex + 10] = (vertIndex + 2) % verts.Length;
                tris[triIndex + 9] = (vertIndex + 3) % verts.Length;

                tris[triIndex + 3] = vertIndex + 1;
                tris[triIndex + 4] = (vertIndex + 2) % verts.Length;
                tris[triIndex + 5] = (vertIndex + 3) % verts.Length;                
            }

            vertIndex += 2;
            triIndex += 12;
        }

        Mesh mesh = new Mesh();
        mesh.vertices = verts;
        mesh.triangles = tris;            
        mesh.uv = uvs;
        mesh.RecalculateNormals();

        return mesh;
    }
}
