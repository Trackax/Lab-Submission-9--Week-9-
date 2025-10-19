using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BulletSettings : MonoBehaviour
{
    private Rigidbody2D rb;
    public float upwardForce;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        ApplyUpwardForce();
    }

    void ApplyUpwardForce()
    {
        if (rb != null)
        {
            rb.AddForce(Vector2.up * upwardForce, ForceMode2D.Impulse);
        }
    }
}
