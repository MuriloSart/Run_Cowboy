using Entities.Interfaces;
using UnityEngine;

namespace Entities
{
    public abstract class Entity : MonoBehaviour
    {
        private GameObject _gameObject;
        public GameObject GameObject { get => _gameObject; }

        private void Start()
        {
            _gameObject = GetComponent<GameObject>();
        }


    }
}