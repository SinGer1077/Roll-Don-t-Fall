using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RollDontFall.TrackModule;

public abstract class Chank
{
    public float Length { get; set; }    

    private GameObject _gameObject;

    public GameObject GameObject => _gameObject;

    private int _difficultLevel;

    public int DifficultLevel => _difficultLevel;

    private Vector3 _firstPosition;

    public Vector3 FirstPosition => _firstPosition;

    private Vector3 _lastPosition;

    public Vector3 LastPosistion => _lastPosition;

    private List<TrackChank> _bezierLines;

    public List<TrackChank> BezierLines => _bezierLines;

    private Material _chankMaterial;

    public Chank(GameObject gameObject, int difficultLevel, Vector3 firstPosition, Material material)
    {
        _gameObject = gameObject;
        _difficultLevel = difficultLevel;
        _firstPosition = firstPosition;
        _chankMaterial = material;
        Length = 40f;

        _bezierLines = new List<TrackChank>();

        GenerateChank();
        GenerateSubLinesObjects();
    }

    public void AddBezierLine(TrackChank line)
    {
        _bezierLines.Add(line);
    }

    public void SetLastPos(Vector3 position)
    {
        _lastPosition = position;
    }

    public abstract void GenerateChank();       

    public virtual void AddComponentsOnGO(GameObject go, TrackChank chank)
    {
        go.tag = "Track";

        MeshRenderer meshRenderer = go.AddComponent<MeshRenderer>();
        meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
        meshRenderer.material = _chankMaterial;
        
        MeshFilter meshFilter = go.AddComponent<MeshFilter>();
        meshFilter.sharedMesh = chank.ChankMesh;

        MeshCollider collider = go.AddComponent<MeshCollider>();
        collider.sharedMesh = chank.ChankMesh;
    }

    public void GenerateSubLinesObjects()
    {
        for (int i = 0; i < _bezierLines.Count; i++)
        {
            GameObject child = new GameObject();
            child.transform.SetParent(_gameObject.transform);
            AddComponentsOnGO(child, _bezierLines[i]);
        }
    }   
}
