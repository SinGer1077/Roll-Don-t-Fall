using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathChankCreator : MonoBehaviour, IChank
{
    [SerializeField]
    private Material _material;

    private int _difficultLevel = 1;

    private RoadCreator _path;

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
        _path = this.gameObject.AddComponent<RoadCreator>();
        GetComponent<MeshRenderer>().sharedMaterial = _levelController.LevelMaterials[_levelController.CurrentDifficultLevel - 1];
        _path.UpdateRoad();
    }
}
