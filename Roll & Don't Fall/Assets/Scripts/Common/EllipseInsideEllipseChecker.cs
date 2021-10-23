using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllipseInsideEllipseChecker : MonoBehaviour
{
    [SerializeField]
    private RectTransform _smallEllipse;

    [SerializeField]
    private RectTransform _bigEllipse;

    public bool CheckEllipseInside()
    {
        float r = _smallEllipse.rect.width / 2;
        float R = _bigEllipse.rect.width / 2;
        if (R * R > Mathf.Pow(_bigEllipse.rect.position.x - _smallEllipse.rect.position.x, 2) +
            Mathf.Pow(_bigEllipse.rect.position.y - _smallEllipse.rect.position.y, 2) +
            r * r)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
