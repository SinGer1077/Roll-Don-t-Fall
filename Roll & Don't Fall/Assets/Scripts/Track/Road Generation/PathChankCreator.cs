using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathChankCreator : MonoBehaviour, IChank
{
    private int _difficultLevel = 1;

    public PathChankCreator()
    {

    }

    public int GetDifficultLevel()
    {
        return _difficultLevel;
    }
    

    private void Start()
    {
        
    }

    public void Create()
    {

    }
}
