using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    public List<IChank> _accessibleChankTypes = new List<IChank>();

    private void Start()
    {        
        GenerateChank();
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
    }
        
}
