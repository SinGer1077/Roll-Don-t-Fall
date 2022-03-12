using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IChank
{
    int GetDifficultLevel();

    Vector3 GetEndPoint();

    void SetStartPoint(Vector3 startPoint);

    void Create();
}
