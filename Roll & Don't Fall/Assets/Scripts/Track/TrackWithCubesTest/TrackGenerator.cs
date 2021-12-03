using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

using UnityEngine;

namespace RollDontFall.TrackModule
{
    public class TrackGenerator : MonoBehaviour
    {
        [SerializeField]
        private Transform _parent;

        [SerializeField]
        private Transform _firstPosition;

        [SerializeField]
        private int _defaultChankCount = 10;

        [SerializeField]
        private Material[] _materialsForChanks;

        private Queue<KeyValuePair<GameObject, Chank>> _chankList;        

        private Type[] _chankTypes;

        private int _currentDiffucultLevel = 0;

        private float _beginningLevelLength = 40f;

        private Vector3 _lastPointPosition;

        void Start()
        {
            _chankList = new Queue<KeyValuePair<GameObject, Chank>>();
            _chankTypes = GetAllChankSubTypes();
            _lastPointPosition = _firstPosition.position;

            IncreaseDifficultLevel();
            GenerateRandomChanks(_defaultChankCount);
        }       

        void Update()
        {

        }

        public void IncreaseDifficultLevel()
        {
            _currentDiffucultLevel++;
            GameObject gameObject = AddGameObject();
            StraightChank straightChank = new StraightChank(gameObject, _currentDiffucultLevel, _lastPointPosition, _beginningLevelLength, _materialsForChanks[_currentDiffucultLevel-1]);
            AddChankToQueue(gameObject, straightChank); 
        }

        public void GenerateRandomChanks(int count)
        {          
            for (int i = 0; i < count; i++)
            {
                GameObject gameObject = AddGameObject();
                Chank chank = (Chank)Activator.CreateInstance(_chankTypes[UnityEngine.Random.Range(0, _chankTypes.Length)], gameObject,
                    _currentDiffucultLevel, _lastPointPosition, _materialsForChanks[_currentDiffucultLevel - 1]);
                AddChankToQueue(gameObject, chank);
            }
        }

        private Type[] GetAllChankSubTypes()
        {
            var ourType = typeof(Chank);
            Type[] types = Assembly.GetAssembly(ourType).GetTypes().Where(type => type.IsSubclassOf(ourType)).ToArray();
            return types;
        }     
        
        private void AddChankToQueue(GameObject gameObject, Chank chank)
        {
            KeyValuePair<GameObject, Chank> pair = new KeyValuePair<GameObject, Chank>(gameObject, chank);
            _chankList.Enqueue(pair);

            _lastPointPosition = chank.LastPosistion;
        }

        private GameObject AddGameObject()
        {
            GameObject gameObject = new GameObject();
            gameObject.transform.SetParent(_parent);
            return gameObject;
        }
    }   
}