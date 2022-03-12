using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownChank : MonoBehaviour, IChank
{
    private Vector3 _startPoint;

    private Vector3 _endPoint;

    private int _difficultLevel = 1;

    private DifficultLevelController _levelController;

    private Material _material;


    private float _blockLenght = 5f;

    public int GetDifficultLevel()
    {
        return _difficultLevel;
    }

    public Vector3 GetEndPoint()
    {
        return _endPoint;
    }

    public void SetStartPoint(Vector3 startPoint)
    {
        _startPoint = startPoint;
    }

    public void Create()
    {
        _levelController = FindObjectOfType<DifficultLevelController>();

        int blockCounts = _levelController.CurrentDifficultLevel;
        _endPoint = _startPoint;

        for (int i = 0; i < blockCounts; i++)
        {
            CreateBlock();
        }       
    }

    private void CreateBlock()
    {
        GameObject platform = GameObject.CreatePrimitive(PrimitiveType.Cube);
        platform.transform.position = _endPoint;
        platform.transform.localScale = new Vector3(6 - _levelController.CurrentDifficultLevel, 0.2f, _blockLenght);
        platform.transform.parent = transform;

        platform.AddComponent<UpDownUpdater>();

        _endPoint = new Vector3(_endPoint.x, _endPoint.y, _endPoint.z + _blockLenght);
    }
}
