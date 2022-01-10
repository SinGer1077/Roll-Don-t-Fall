using System;
using System.Linq;
using System.Reflection;

using UnityEngine;

public class DifficultLevelController : MonoBehaviour
{
    [SerializeField]
    private RoadGenerator _roadGenerator;

    private int _currentDifficultLevel = 0;


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
    }

    private void AddAccessChankTypeToRoadGenerator(int difficultLevel)
    {
        foreach (Type chank in _chankTypes)
        {
            IChank type = (IChank)Activator.CreateInstance(chank);
            if ((type as IChank).GetDifficultLevel() == difficultLevel)
            {
                _roadGenerator.AddAccessibleChankType(type as IChank);
            }
        }
        
    }

    private Type[] GetAllChankSubTypes()
    {
        var ourType = typeof(IChank);
        var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()).Where(p => ourType.IsAssignableFrom(p) && !p.IsInterface).ToArray();        
        return types;
    }
}
