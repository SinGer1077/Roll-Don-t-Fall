using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    [SerializeField]
    private DifficultLevelController _levelController;

    private List<IChank> _accessibleChankTypes = new List<IChank>();

    private Vector3 _lastPosition;

    public Vector3 LastPosition => _lastPosition;

    private void Awake()
    {
        _lastPosition = transform.position;
    }

    private void Start()
    {
        GeneratePathChankCreator();

        for (int i = 0; i < 10; i++)
        {
            GenerateRandomChank();
        }
       
    }

    public void AddAccessibleChankType(IChank chankType)
    {
        _accessibleChankTypes.Add(chankType);
    }

    public void GenerateRandomChank()
    {
        IChank chank = _accessibleChankTypes[UnityEngine.Random.Range(0, _accessibleChankTypes.Count)];
        GenerateChank(chank.GetType());
    }

    public void GeneratePathChankCreator()
    {
        IChank chank = _accessibleChankTypes.First(x => x.GetType() == typeof(PathChankCreator));

        if (chank == null)
        {
            GenerateRandomChank();
        }
        else
        {
            GenerateChank(chank.GetType());
        }
    }

    public void GenerateChank(Type chankType)
    {        
        GameObject goChank = new GameObject("Chank", chankType);
        goChank.transform.SetParent(this.transform);

        IChank component = goChank.GetComponent<IChank>();
        component.SetStartPoint(_lastPosition);
        component.Create();

        _levelController.CheckIncreasingDifficultLevel(_lastPosition);
    }

    public void UpdateLastPosition(Vector3 newPos)
    {
        _lastPosition = newPos;
    }

    
        
}
