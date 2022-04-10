using System;
using System.Linq;
using System.Reflection;

using UnityEngine;

public class DifficultLevelController : MonoBehaviour
{
    [SerializeField]
    private RoadGenerator _roadGenerator;

    [SerializeField]
    private Material[] _levelMaterials;

    [SerializeField]
    private float _distanceToChangeLevel;

    public Material[] LevelMaterials => _levelMaterials;

    private int _currentDifficultLevel = 0;

    public int CurrentDifficultLevel => _currentDifficultLevel;


    private Type[] _chankTypes;

    private void Awake()
    {
        _chankTypes = GetAllChankSubTypes();
        IncreaseDifficultLevel();        
    }

    public void IncreaseDifficultLevel()
    {
        _currentDifficultLevel++;
        AddAccessChankTypeToRoadGenerator(_currentDifficultLevel);

        Debug.Log(_currentDifficultLevel);
    }

    private void AddAccessChankTypeToRoadGenerator(int difficultLevel)
    {
        foreach (Type chank in _chankTypes)
        {
            IChank type = (IChank)Activator.CreateInstance(chank);
            if (type.GetDifficultLevel() <= difficultLevel)
            {
                _roadGenerator.AddAccessibleChankType(type);
            }
        }
        
    }

    private Type[] GetAllChankSubTypes()
    {
        var ourType = typeof(IChank);
        var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()).Where(p => ourType.IsAssignableFrom(p) && !p.IsInterface).ToArray();        
        return types;
    }

    public void CheckIncreasingDifficultLevel(Vector3 lastPosition)
    {
        float distance = Vector3.Distance(Vector3.zero, lastPosition);

        if (distance % _distanceToChangeLevel > _currentDifficultLevel && _currentDifficultLevel != _levelMaterials.Length)
        {
            IncreaseDifficultLevel();            
        }
    }
}
