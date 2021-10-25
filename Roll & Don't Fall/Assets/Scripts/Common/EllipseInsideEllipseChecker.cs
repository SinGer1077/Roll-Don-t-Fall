using UnityEngine;

public class EllipseInsideEllipseChecker : MonoBehaviour
{
    [SerializeField]
    private RectTransform _smallEllipse;

    [SerializeField]
    private RectTransform _bigEllipse;

    public bool CheckEllipseInside(Vector2 newPosition)
    {
        float r = _smallEllipse.rect.width / 2;
        float R = _bigEllipse.rect.width / 2;
        if (R * R > Mathf.Pow(_bigEllipse.position.x - newPosition.x, 2) +
            Mathf.Pow(_bigEllipse.position.y - newPosition.y, 2)
            + 5 * r * r)
        {            
            return true;            
        }
        else
        {            
            return false;
        }
    }
}
