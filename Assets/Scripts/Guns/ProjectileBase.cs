using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    protected float timeToDestroy = 2f;
    [HideInInspector] public float speed = 1f;
    public List<string> tagsToHit;
    public int damageAmount = 1;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void Active()
    {
        gameObject.SetActive(true);
        StartCoroutine(timeToDesactive(timeToDestroy));
    }

    private IEnumerator timeToDesactive(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (var t in tagsToHit)
        {
            var damageable = collision.transform.GetComponent<IDamageable>();
            if (collision.transform.tag == t)
            {
                if (damageable != null)
                {
                    Vector3 dir = collision.transform.position - transform.position;
                    dir = -dir.normalized;
                    dir.y = 0;

                    damageable.Damage(damageAmount, dir);
                }
                break;
            }
        }
        gameObject.SetActive(false);
    }
}