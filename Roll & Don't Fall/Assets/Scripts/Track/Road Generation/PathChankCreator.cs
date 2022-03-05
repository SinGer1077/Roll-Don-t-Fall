using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathChankCreator : MonoBehaviour, IChank
{
    [SerializeField]
    private Material _material;

    private int _difficultLevel = 1;

    private Vector3 _endPoint;

    private RoadCreator _pathMesh;

    private PathCreator _pathCurve;

    private DifficultLevelController _levelController;

    public PathChankCreator()
    {

    }

    public int GetDifficultLevel()
    {
        return _difficultLevel;
    }
    

    private void Start()
    {
        _levelController = FindObjectOfType<DifficultLevelController>();
        Create();
    }

    public void Create()
    {
        _pathMesh = this.gameObject.AddComponent<RoadCreator>();
        GetComponent<MeshRenderer>().sharedMaterial = _levelController.LevelMaterials[_levelController.CurrentDifficultLevel - 1];
        _pathMesh.UpdateRoad();

        _pathCurve = _pathMesh.GetComponent<PathCreator>();

        _endPoint = _pathCurve.path[_pathCurve.path.NumPoints - 1];


        AddForwardSegment(9f);
        for (int i = 0; i < 5; i++)
        {
            AddSegment();
        }
        AddForwardSegment(15f);
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
        Vector3 newPoint = new Vector3(
            _endPoint.x + Random.Range(-5, 5),
            _endPoint.y + Random.Range(-1, 1),
            _endPoint.z + Random.Range(-5, 5)
            );

        return newPoint;
    }

    public Vector3 GetEndPoint()
    {
        return _endPoint;
    }
}
