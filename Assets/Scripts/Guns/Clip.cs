using System.Collections.Generic;
using UnityEngine;

namespace Guns
{ 
    public class Clip : MonoBehaviour
    {
        public ProjectileBase prefabProjectile;
        public int projectilesAmount;

        public List<ProjectileBase> ammu;
        private int _currentBullet = 0;

        private void Awake()
        {
            transform.LookAt(Camera.main.transform.position + Camera.main.transform.forward * 1000);
        }

        private void Start()
        {
            for (int i = 0; i < projectilesAmount; i++)
            {
                var currentProjectile = Instantiate(prefabProjectile);
                ammu.Add(currentProjectile);
            }
        }

        public void Fire(Transform positionToShoot, float speed)
        {
            if (ammu[_currentBullet].isActiveAndEnabled) return;

            ammu[_currentBullet].Active();
            ammu[_currentBullet].transform.SetPositionAndRotation(positionToShoot.position, positionToShoot.rotation);
            ammu[_currentBullet].speed = speed;
            _currentBullet++;
        }

        private void Update()
        {
            if (_currentBullet >= ammu.Count) _currentBullet = 0;
        }
    }
}
