using System.Collections;
using Entities.Health;
using UnityEngine;

namespace Guns
{
    public class Shoot : MonoBehaviour
    {
        [Header("Saída da arma")]
        public Transform gaugeOutlet;

        [Header("Carregador")]
        public Clip clip;

        [Header("Velocidade dos Disparos")]
        public float timeBetweenShoot = .2f;

        public float projectileSpeed = 1f;

        [Header("Dano da Arma")]

        public int damage = 1;

        #region private variables
        private bool _canShoot = true;
        private Vector3 bulletDirection;
        private Ray ray;
        private RaycastHit hit;
        #endregion

        public RaycastHit BulletCollisor { get => hit; }

        public void Perform()
        {
            StartCoroutine(ShootCoroutine());
        }

        protected virtual IEnumerator ShootCoroutine()
        {
            if (!_canShoot) yield break;

            int layerMask = ~LayerMask.GetMask("NavMesh");

            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);


            ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));

            bulletDirection = Physics.Raycast(ray, out hit, 1000, layerMask) 
                ? (hit.point - gaugeOutlet.position).normalized 
                : ray.direction;

            _canShoot = false;

            if (hit.collider.TryGetComponent<Health>(out Health health)) health.Damage(damage);

            Debug.Log(hit.collider.name);

            yield return new WaitForSeconds(timeBetweenShoot);

            _canShoot = true;
        }
    }

}
