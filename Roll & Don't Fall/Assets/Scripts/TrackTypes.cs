using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TrackTypes
{ 
    public static Vector3[] Straight(Vector3 firstPoint)
    {
        float trackLength = 40f;

        Vector3 secondPosition = new Vector3(firstPoint.x, firstPoint.y, firstPoint.z + trackLength / 4);
        Vector3 thirdPosition = new Vector3(firstPoint.x, firstPoint.y, secondPosition.z + trackLength / 4);
        Vector3 fourthPosition = new Vector3(firstPoint.x, firstPoint.y, thirdPosition.z + trackLength / 4);
        return new Vector3[] {firstPoint, secondPosition, thirdPosition, fourthPosition};
    }

    public static Vector3[] HorizontalArc(Vector3 firstPoint)
    {
        float trackLength = 40f;
        float arcDistance = -40f;

        Vector3 secondPosition = new Vector3(firstPoint.x, firstPoint.y, firstPoint.z + trackLength / 4);
        Vector3 thirdPosition = new Vector3(firstPoint.x + arcDistance, firstPoint.y, secondPosition.z + trackLength / 4);
        Vector3 fourthPosition = new Vector3(firstPoint.x, firstPoint.y, thirdPosition.z + trackLength / 4);
        return new Vector3[] { firstPoint, secondPosition, thirdPosition, fourthPosition };
    }

    public static Vector3[] DoubleHorizontalArc(Vector3 firstPoint)
    {
        float trackLength = 40f;
        float firstArcDistance = 40f;
        float secondArcDistance = -40f;

        Vector3 secondPosition = new Vector3(firstPoint.x + firstArcDistance, firstPoint.y, firstPoint.z + trackLength / 4);
        Vector3 thirdPosition = new Vector3(firstPoint.x + secondArcDistance, firstPoint.y, secondPosition.z + trackLength / 4);
        Vector3 fourthPosition = new Vector3(firstPoint.x, firstPoint.y, thirdPosition.z + trackLength / 4);
        return new Vector3[] { firstPoint, secondPosition, thirdPosition, fourthPosition };
    }

    public static Vector3[] GetRandomTrackType(Vector3 firstPoint, int trackType)
    {
        Vector3[] array = new Vector3[] { };
        switch (trackType)
        {
            case 0:
                array = Straight(firstPoint);
                break;
            case 1:
                array = HorizontalArc(firstPoint);
                break;
            case 2:
                array = DoubleHorizontalArc(firstPoint);
                break;
        }
        return array;
    }
}
