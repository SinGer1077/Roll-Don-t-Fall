using UnityEngine;

namespace RollDontFall.TrackModule
{
    public class BezierTest : MonoBehaviour
    {
        public Transform p0;
        public Transform p1;
        public Transform p2;
        public Transform p3;

        public float t;

        private void OnDrawGizmos()
        {
            int sigmentNubmer = 5;
            Vector3 previousPoint = p0.position;

            Vector3 p01 = new Vector3(p0.position.x + 5, p0.position.y, p0.position.z);
            Vector3 p11 = new Vector3(p1.position.x + 5, p1.position.y, p1.position.z);
            Vector3 p21 = new Vector3(p2.position.x + 5, p2.position.y, p2.position.z);
            Vector3 p31 = new Vector3(p3.position.x + 5, p3.position.y, p3.position.z);

            Vector3 secondPreviousPoint = p01;

            for (int i = 0; i < sigmentNubmer + 1; i++)
            {
                float parameter = (float)i / sigmentNubmer;
                Vector3 point = Bezier.GetPoint(p0.position, p1.position, p2.position, p3.position, parameter);
                Vector3 secondPoint = Bezier.GetPoint(p01, p11, p21, p31, parameter);
                Gizmos.DrawLine(previousPoint, point);
                Gizmos.DrawLine(secondPreviousPoint, secondPoint);
                previousPoint = point;
                secondPreviousPoint = secondPoint;
            }
        }
    }
}
