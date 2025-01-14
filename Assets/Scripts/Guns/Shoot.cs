using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform gaugeOutlet;
    public Clip clip;
    public float timeBetweenShoot = .2f;
    public float projectileSpeed = 1f;

    private bool _canShoot = true;

    private RaycastHit hit;
    public RaycastHit BulletCollisor { get => hit; }

    public void Perform()
    {
        StartCoroutine(ShootCoroutine());
    }

    public virtual IEnumerator ShootCoroutine()
    {
        if (!_canShoot) yield break;

        clip.Fire(gaugeOutlet, projectileSpeed);
        _canShoot = false;

        var destiny = Camera.main.transform.position + Camera.main.transform.forward * 1000;
            
        var collided = Physics.Raycast(gaugeOutlet.position, destiny, out hit, 1000);

        yield return new WaitForSeconds(timeBetweenShoot);
        _canShoot = true;
    }
}
