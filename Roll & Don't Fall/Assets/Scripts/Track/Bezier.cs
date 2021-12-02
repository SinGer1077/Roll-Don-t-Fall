﻿using UnityEngine;

namespace RollDontFall.TrackModule
{
    public static class Bezier
    {
        //public static Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
        //{
        //    Vector3 p01 = Vector3.Lerp(p0, p1, t);
        //    Vector3 p12 = Vector3.Lerp(p1, p2, t);
        //    Vector3 p23 = Vector3.Lerp(p2, p3, t);

        //    Vector3 p012 = Vector3.Lerp(p01, p12, t);
        //    Vector3 p123 = Vector3.Lerp(p12, p23, t);

        //    Vector3 p0123 = Vector3.Lerp(p012, p123, t);

        //    return p0123;
        //}

        public static Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
        {
            t = Mathf.Clamp01(t);
            float oneMinusT = 1f - t;
            return
                oneMinusT * oneMinusT * oneMinusT * p0 +
                3f * oneMinusT * oneMinusT * t * p1 +
                3f * oneMinusT * t * t * p2 +
                t * t * t * p3;
        }
    }
}
