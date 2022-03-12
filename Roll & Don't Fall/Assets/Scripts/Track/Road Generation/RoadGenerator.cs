using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    public List<IChank> _accessibleChankTypes = new List<IChank>();

    public Vector3 _lastPosition;

    private void Awake()
    {
        _lastPosition = transform.position;
    }

    private void Start()
    {        
        GenerateChank();
        //Debug.Log(_lastPosition);
        GenerateChank();
        //Debug.Log(_lastPosition);
    }

    public void AddAccessibleChankType(IChank chankType)
    {
        _accessibleChankTypes.Add(chankType);
    }

    public void GenerateChank()
    {
        IChank chank = _accessibleChankTypes[UnityEngine.Random.Range(0, _accessibleChankTypes.Count)];
        GameObject goChank = new GameObject("Chank", chank.GetType());
        goChank.transform.SetParent(this.transform);

        IChank component = goChank.GetComponent<IChank>();
        component.SetStartPoint(_lastPosition);
        component.Create();
    }

    public void UpdateLastPosition(Vector3 newPos)
    {
        _lastPosition = newPos;
    }
        
}
