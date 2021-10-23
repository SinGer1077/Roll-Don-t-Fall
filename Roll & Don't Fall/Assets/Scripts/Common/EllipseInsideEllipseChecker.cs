using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllipseInsideEllipseChecker : MonoBehaviour
{
    [SerializeField]
    private RectTransform _smallEllipse;

    [SerializeField]
    private RectTransform _bigEllipse;

    public void CheckEllipseInside()
    {
        float r = _smallEllipse.rect.width / 2;
        float R = _bigEllipse.rect.width / 2;
        if (R * R > Mathf.Pow(_bigEllipse.anchoredPosition.x - _smallEllipse.anchoredPosition.x, 2) +
            Mathf.Pow(_bigEllipse.anchoredPosition.y - _smallEllipse.anchoredPosition.y, 2) +
            r * r)
        {
            Debug.Log("Inside");
            //return true;
        }
        else
        {
            Debug.Log("Outside");
            //return false;
        }
    }
}
