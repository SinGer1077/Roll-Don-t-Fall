using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackChankGenerator : MonoBehaviour
{
    [SerializeField]
    private Transform _parent;

    [SerializeField]
    private Transform _firstPosition;

    [SerializeField]
    private int _defaultChanksCount = 100;

    private List<GameObject> _chankList;

    private List<TrackChank> _chankData;

    private Vector3 _lastPointPosition;

    private float _trackFirstPointX = 0f;

    private float _trackFirstPointZ = 0f;

    private float _trackSecondPointX = 0f;

    private float _trackSecondPointZ = 0f;

    private void Start()
    {
        Debug.Log("Программа началась ");

        _chankList = new List<GameObject>();
        _chankData = new List<TrackChank>();
        _lastPointPosition = _firstPosition.position;

        GenerateChanks(_defaultChanksCount);
    }

    private void GenerateChanks(int chankCount)
    {
        for (int i = 0; i < chankCount; i++)
        {
            GameObject chank = new GameObject("Chank");            
            chank.transform.SetParent(_parent);

            TrackChank chankData = new TrackChank(new Vector3[] {_lastPointPosition,  NextFirstpointPositionRandomizer(), NextSecondpointPositionRandomizer(), _lastPointPosition});
            chankData.FormChank();

            MeshRenderer meshRenderer = chank.AddComponent<MeshRenderer>();
            meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));

            MeshFilter meshFilter = chank.AddComponent<MeshFilter>();            
            meshFilter.sharedMesh =  chankData.ChankMesh;            

            MeshCollider collider = chank.AddComponent<MeshCollider>();
            collider.sharedMesh = chankData.ChankMesh;           

            _chankList.Add(chank);
            _chankData.Add(chankData);           
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(_lastPointPosition, 10.0f);
    }

    private Vector3 NextFirstpointPositionRandomizer()
    {
        _trackFirstPointX += Random.Range(5f, 15f);
        _trackFirstPointZ += Random.Range(-30f, 30f);
        Vector3 result = new Vector3(_lastPointPosition.x + _trackFirstPointX, _lastPointPosition.y, _lastPointPosition.z + _trackFirstPointZ);
        _lastPointPosition = result;

        GameObject mya = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        mya.transform.position = _lastPointPosition;
        
        return _lastPointPosition;
    }
    private Vector3 NextSecondpointPositionRandomizer()
    {
        _trackSecondPointX += Random.Range(5f, 15f);
        _trackSecondPointZ += Random.Range(-30f, 30f);
        Vector3 result = new Vector3(_lastPointPosition.x + _trackSecondPointX, _lastPointPosition.y, _lastPointPosition.z + _trackSecondPointZ);
        _lastPointPosition = result;

        GameObject mya = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        mya.transform.position = _lastPointPosition;

        return _lastPointPosition;
    }
}
