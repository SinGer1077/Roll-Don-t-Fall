using System.Collections.Generic;
using UnityEngine;

namespace RollDontFall.TrackModule
{
    public class TrackChankGenerator : MonoBehaviour
    {
        [SerializeField]
        private Transform _parent;

        [SerializeField]
        private Transform _firstPosition;

        [SerializeField]
        private int _defaultChanksCount = 10;

        [SerializeField]
        private RuntimeAnimatorController _chankUpDownAnimation;

        [SerializeField]
        private Material _trackMaterial;

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
        }

        private void GenerateChanks(int chankCount)
        {
            for (int i = 0; i < chankCount; i++)
            {
                GameObject chank = new GameObject("Chank");
                chank.transform.SetParent(_parent);

                int random = Random.Range(0, 3);
                TrackChank chankData = new TrackChank(TrackTypes.GetRandomTrackType(_lastPointPosition, random));
                chankData.FormChank();

                MeshRenderer meshRenderer = chank.AddComponent<MeshRenderer>();
                meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
                meshRenderer.material = _trackMaterial;

                MeshFilter meshFilter = chank.AddComponent<MeshFilter>();
                meshFilter.sharedMesh = chankData.ChankMesh;

                MeshCollider collider = chank.AddComponent<MeshCollider>();
                collider.sharedMesh = chankData.ChankMesh;

                if (random == (int)TrackTypes.Types.Straight)
                {
                    int changeToAnimate = Random.Range(0, 100);
                    if (changeToAnimate > 75)
                    {
                        Animator animator = chank.AddComponent<Animator>();
                        animator.runtimeAnimatorController = _chankUpDownAnimation;
                    }
                }

                _chankList.Add(chank);
                _chankData.Add(chankData);

                _lastPointPosition = chankData.BasePoints[3];
            }
        }        
    }
}
