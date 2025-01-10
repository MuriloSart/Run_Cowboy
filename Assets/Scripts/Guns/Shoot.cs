using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform gaugeOutlet;
    public Clip clip;
    public float timeBetweenShoot = .2f;
    public float projectileSpeed = 1f;

    private bool canShoot = true;

    public void Perform()
    {
        StartCoroutine(ShootCoroutine());
    }

    public virtual IEnumerator ShootCoroutine()
    {
        if (!canShoot) yield break;

        clip.Fire(gaugeOutlet, projectileSpeed);
        canShoot = false;

        yield return new WaitForSeconds(timeBetweenShoot);
        canShoot = true;
    }
}
