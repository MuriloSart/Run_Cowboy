using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entities.Health;

namespace Guns
{
    public class ProjectileBase : MonoBehaviour
    {
        protected float timeToDestroy = 2f;
        public List<string> tagsToHit;
        public int damageAmount = 1;
        [HideInInspector] public float speed = 1f;
        [HideInInspector] public Vector3 bulletDirection = Vector3.forward;

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public void Activate(Vector3 startPosition, Vector3 targetDirection)
        {
            transform.position = startPosition;
            bulletDirection = targetDirection.normalized;

            gameObject.SetActive(true);
            StartCoroutine(DeactivateAfterTime(timeToDestroy));
        }

        private IEnumerator DeactivateAfterTime(float time)
        {
            yield return new WaitForSeconds(time);
            gameObject.SetActive(false);
        }

        private void Update()
        {
            transform.Translate(speed * Time.deltaTime * bulletDirection, Space.World);
        }

        private void OnCollisionEnter(Collision collision)
        {
            foreach (var tag in tagsToHit)
            {
                if (collision.transform.CompareTag(tag))
                {
                    var damageable = collision.transform.GetComponent<Health>();
                    if (damageable != null)
                    {
                        Vector3 dir = (collision.transform.position - transform.position).normalized;
                        dir.y = 0;
                        damageable.Damage(damageAmount);
                    }
                    break;
                }
            }

            gameObject.SetActive(false);
        }
    }
}