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
    private int _defaultChanksCount = 10;

    private List<GameObject> _chankList;

    private List<TrackChank> _chankData;

    private Vector3 _lastPointPosition;

    private void Start()
    {
        Debug.Log("Программа началась ");

        _chankList = new List<GameObject>();
        _chankData = new List<TrackChank>();
        _lastPointPosition = _firstPosition.position;

        GenerateChanks(_defaultChanksCount);

        //Example();
    }

    private void GenerateChanks(int chankCount)
    {
        for (int i = 0; i < chankCount; i++)
        {
            GameObject chank = new GameObject("Chank");            
            chank.transform.SetParent(_parent);

            TrackChank chankData = new TrackChank(new Vector3[] {_lastPointPosition,  NextPositionRandomizer(), NextPositionRandomizer(), NextPositionRandomizer()});
            chankData.FormChank();

            MeshRenderer meshRenderer = chank.AddComponent<MeshRenderer>();
            meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));

            MeshFilter meshFilter = chank.AddComponent<MeshFilter>();            
            meshFilter.sharedMesh =  chankData.ChankMesh;            

            MeshCollider collider = chank.AddComponent<MeshCollider>();
            collider.sharedMesh = chankData.ChankMesh;

            //Quaternion 
            //chank.transform.rotation

            _chankList.Add(chank);
            _chankData.Add(chankData);           
        }
    }

    private void OnDrawGizmos()
    {
        //for (int i = 0; i < _chankData[0].ChankMesh.vertices.Length; i++)
        //{
        //    Gizmos.DrawSphere(_chankData[0].ChankMesh.vertices[i], 0.1f);
        //}

        //foreach (TrackChank x in _chankData)
        //{
        //    Gizmos.DrawMesh(x.ChankMesh);
        //}
    }

    private Vector3 NextPositionRandomizer()
    {
        float z = Random.Range(5f, 15f);
        float x = Random.Range(-15f, 15f);
        Vector3 result = new Vector3(_lastPointPosition.x + x, _lastPointPosition.y, _lastPointPosition.z + z);
        _lastPointPosition = result;
        
        return _lastPointPosition;
    }

    public void Example()
    {
        float width = 1;
        float height = 1;

        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));

        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();

        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[4]
        {
            new Vector3(0, 0, 0),
            new Vector3(width, 0, 0),
            new Vector3(0, height, 0),
            new Vector3(width, height, 0)
        };
        mesh.vertices = vertices;

        int[] tris = new int[6]
        {
            // lower left triangle
            0, 2, 1,
            // upper right triangle
            2, 3, 1
        };
        mesh.triangles = tris;

        Vector3[] normals = new Vector3[4]
        {
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward
        };
        //mesh.normals = normals;

        Vector2[] uv = new Vector2[4]
        {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(1, 1)
        };
        //mesh.uv = uv;

        meshFilter.mesh = mesh;
    }
}
