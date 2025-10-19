using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ObjectPool bulletPool;
    public float bulletSpeed = 10f;
    public GameObject shootPoint;

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
        bullet.transform.position = shootPoint.transform.position;
        bullet.transform.rotation = transform.rotation;

        StartCoroutine(DeactivateBullet(bullet));
    }

    IEnumerator DeactivateBullet (GameObject bullet)
    {
        yield return new WaitForSeconds(2f);
        bulletPool.ReturnObject(bullet);
    }
}
