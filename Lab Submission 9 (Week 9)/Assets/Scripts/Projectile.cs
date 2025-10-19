using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed;

    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }
}
