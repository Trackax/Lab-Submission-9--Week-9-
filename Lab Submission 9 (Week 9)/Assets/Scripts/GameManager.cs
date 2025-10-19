using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BulletPool bulletPool;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = bulletPool.GetObject();
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;

        StartCoroutine(DeactivateBullet(bullet));
    }

    IEnumerator DeactivateBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(1f);
        bulletPool.ReturnObject(bullet);
    }
}
