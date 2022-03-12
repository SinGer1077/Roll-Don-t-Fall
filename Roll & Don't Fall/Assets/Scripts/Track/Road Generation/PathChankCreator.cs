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

    private List<Vector3> _possibleDirections = new List<Vector3>()
    {
        new Vector3(0, 0, 1),
        new Vector3(1, 0, 1),
        new Vector3(-1, 0, 1),
        new Vector3(0, -1, 1),
        new Vector3(1, -1, 1),
        new Vector3(-1, -1, 1),
        new Vector3(0, 1, 1),
        new Vector3(1, 1, 1),
        new Vector3(-1, 1, 1),
    };

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


        AddForwardSegment(29f);
        for (int i = 0; i < (_levelController.CurrentDifficultLevel + 1) * 20; i++)
        {
            AddSegment();
        }
        AddForwardSegment(5f);
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
        //Vector3 newPoint = new Vector3(
        //    _endPoint.x + Random.Range(-10, 10),
        //    _endPoint.y + Random.Range(-3, 3),
        //    _endPoint.z + Random.Range(2, 5)
        //    );

        
        float z = _endPoint.z + GetRandomCoefWithLevelDifficult(5f);        
        float x = GetRandomCoefWithLevelDifficult(5f) + GetRandomCoefWithLevelDifficult(5f) * Mathf.Sin(GetRandomCoefWithLevelDifficult(5f) * z + GetRandomCoefWithLevelDifficult(5f));     
        float y = GetRandomCoefWithLevelDifficult(1f) + GetRandomCoefWithLevelDifficult(1f) * Mathf.Sin(GetRandomCoefWithLevelDifficult(1f) * z + GetRandomCoefWithLevelDifficult(1f));
        Vector3 newPoint = new Vector3(x, y, z);

        return newPoint;
    }

    private float GetRandomCoefWithLevelDifficult(float coef)
    {
        return Random.Range(coef * _levelController.CurrentDifficultLevel, coef * (_levelController.CurrentDifficultLevel + 2));
    }

    public Vector3 GetEndPoint()
    {
        return _endPoint;
    }
}
