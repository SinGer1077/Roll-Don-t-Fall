using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathChankCreator : MonoBehaviour, IChank
{
    [SerializeField]
    private Material _material;

    private int _difficultLevel = 1;

    private DifficultLevelController _levelController;

    private Vector3 _startPoint;

    private Vector3 _endPoint;


    
    private RoadCreator _pathMesh;

    private PathCreator _pathCurve;

    private RoadGenerator _roadGenerator;
   

    public PathChankCreator()
    {

    }

    public int GetDifficultLevel()
    {
        return _difficultLevel;
    }

    public void SetStartPoint(Vector3 startPoint)
    {
        _startPoint = startPoint;
    }

    public void Create()
    {
        _levelController = FindObjectOfType<DifficultLevelController>();
        _roadGenerator = transform.GetComponentInParent<RoadGenerator>();

        _pathMesh = this.gameObject.AddComponent<RoadCreator>();
        _pathMesh.roadWidth = 6 - _levelController.CurrentDifficultLevel;
        GetComponent<MeshRenderer>().sharedMaterial = _levelController.LevelMaterials[_levelController.CurrentDifficultLevel - 1];       

        _pathCurve = _pathMesh.GetComponent<PathCreator>();
        _pathCurve.CreatePath(_startPoint);

        _endPoint = _pathCurve.path[_pathCurve.path.NumPoints - 1];

        AddForwardSegment(15f);
        for (int i = 0; i < (_levelController.CurrentDifficultLevel + 1) * 20; i++)
        {
            AddSegment();
        }
        AddForwardSegment(15f);

        _roadGenerator.UpdateLastPosition(_endPoint);
    }

    private void AddForwardSegment(float length)
    {
        Vector3 nextPoint = new Vector3(_endPoint.x, _endPoint.y, _endPoint.z + length);
        CurveUpdate(nextPoint);
    }

    private void AddSegment()
    {
        Vector3 nextPoint = SetNextRandomPoint();
        CurveUpdate(nextPoint);
    }

    private void CurveUpdate(Vector3 nextPoint)
    {
        _pathCurve.path.AddSegment(nextPoint);
        _pathMesh.UpdateRoad();
        _endPoint = nextPoint;
    }

    private Vector3 SetNextRandomPoint()
    {        
        float z = _endPoint.z + GetRandomCoefWithLevelDifficultForZ(5f);        
        float x = GetRandomCoefWithLevelDifficultForX(5f) + GetRandomCoefWithLevelDifficultForX(5f) * Mathf.Sin(GetRandomCoefWithLevelDifficultForX(5f) * z + GetRandomCoefWithLevelDifficultForX(5f));
        //float y = GetRandomCoefWithLevelDifficultForY(1f) + GetRandomCoefWithLevelDifficultForY(1f) * Mathf.Sin(GetRandomCoefWithLevelDifficultForY(1f) * z + GetRandomCoefWithLevelDifficultForY(1f));
        float y = _endPoint.y + Random.Range(-5, 3);
        Vector3 newPoint = new Vector3(x, y, z);

        return newPoint;
    }

    private float GetRandomCoefWithLevelDifficultForX(float coef)
    {
        return Random.Range(-coef * (_levelController.CurrentDifficultLevel + 2), coef * (_levelController.CurrentDifficultLevel + 2));
    }

    private float GetRandomCoefWithLevelDifficultForY(float coef)
    {
        return Random.Range(-coef * (_levelController.CurrentDifficultLevel + 5), coef * _levelController.CurrentDifficultLevel);
    }

    private float GetRandomCoefWithLevelDifficultForZ(float coef)
    {
        return Random.Range(coef * _levelController.CurrentDifficultLevel, coef * (_levelController.CurrentDifficultLevel + 2));
    }

    public Vector3 GetEndPoint()
    {
        return _endPoint;
    }
}
