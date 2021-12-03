using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollDontFall.TrackModule
{
    [ExecuteAlways]
    public class FillTrackWithCubes : MonoBehaviour
    {
        public Transform _cube;

        public Transform p0;
        public Transform p1;
        public Transform p2;
        public Transform p3;

        public float t;

        private void Start()
        {
            int sigmentNubmer = 40;
            Vector3 previousPoint = p0.position;

            for (int i = 1; i < sigmentNubmer + 1; i++)
            {
                float parameter = (float)i / sigmentNubmer;
                Vector3 point = Bezier.GetPoint(p0.position, p1.position, p2.position, p3.position, parameter);

                float distance = Mathf.Sqrt((previousPoint.x - point.x) * (previousPoint.x - point.x) +
                    (previousPoint.x - point.y) * (previousPoint.x - point.y) +
                    (previousPoint.x - point.z) * (previousPoint.x - point.z));

                //Vector3 position = new Vector3((point.x - previousPoint.x) / 2, (point.y - previousPoint.y) / 2, (point.z - previousPoint.z) / 2);

                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = previousPoint;
                ////cube.transform.localScale = new Vector3(distance, distance, distance);
                cube.transform.rotation = Quaternion.LookRotation(Bezier.GetFirstDerivetive(p0.position, p1.position, p2.position, p3.position, parameter));                

                previousPoint = point;
            }
        }

        private void Update()
        {
            _cube.position = Bezier.GetPoint(p0.position, p1.position, p2.position, p3.position, t);
            _cube.rotation = Quaternion.LookRotation(Bezier.GetFirstDerivetive(p0.position, p1.position, p2.position, p3.position, t));
        }

        private void OnDrawGizmos()
        {
            int sigmentNubmer = 20;
            Vector3 previousPoint = p0.position;

            for (int i = 0; i < sigmentNubmer + 1; i++)
            {
                float parameter = (float)i / sigmentNubmer;
                Vector3 point = Bezier.GetPoint(p0.position, p1.position, p2.position, p3.position, parameter); 
                Gizmos.DrawLine(previousPoint, point);
                previousPoint = point;

            }
        }
    }
}
