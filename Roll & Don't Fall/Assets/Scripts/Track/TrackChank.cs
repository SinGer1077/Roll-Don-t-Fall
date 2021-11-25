using System.Collections.Generic;
using UnityEngine;

namespace RollDontFall.TrackModule
{
    public class TrackChank
    {
        private Vector3[] _basePoints;

        public Vector3[] BasePoints => _basePoints;

        private int _sigmentNumber = 20;

        private Vector3 _axisDistance = new Vector3(5f, 0, 0);

        public Vector3 AxisDistance => _axisDistance;

        private Mesh _mesh;

        public Mesh ChankMesh => _mesh;

        public TrackChank(Vector3[] points)
        {
            _basePoints = points;
        }

        public void FormChank()
        {
            List<Vector3> vertices = new List<Vector3>();
            List<int> triangles = new List<int>();
            List<Vector2> uv = new List<Vector2>();

            for (int i = 0; i < _sigmentNumber + 1; i++)
            {
                float parameter = (float)i / _sigmentNumber;
                Vector3 point = Bezier.GetPoint(_basePoints[0], _basePoints[1], _basePoints[2], _basePoints[3], parameter);
                Vector3 secondPoint = new Vector3(point.x + _axisDistance.x, point.y + _axisDistance.y, point.z + _axisDistance.z);

                vertices.Add(secondPoint);
                vertices.Add(point);
                uv.Add(point);
                uv.Add(secondPoint);
            }

            for (int i = 0; i < (_sigmentNumber + 1) * 2 - 2; i += 2)
            {
                triangles.Add(i);
                triangles.Add(i + 1);
                triangles.Add(i + 2);

                triangles.Add(i + 3);
                triangles.Add(i + 2);
                triangles.Add(i + 1);
            }

            _mesh = new Mesh();

            _mesh.vertices = vertices.ToArray();
            _mesh.uv = uv.ToArray();
            _mesh.triangles = triangles.ToArray();
            _mesh.RecalculateNormals();
        }

        public void SetDistance(Vector3 newDistance)
        {
            _axisDistance = newDistance;
        }

        public float GetChankLength()
        {
            return _basePoints[3].z - _basePoints[0].z;
        }
    }
}
