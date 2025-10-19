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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BlackAndWhite")
        {
            Destroy(collision.gameObject);
            ScoreManager.instance.Add100Points();
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "RedAndOrange")
        {
            Destroy(collision.gameObject);
            ScoreManager.instance.Add300Points();
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "BlueAndYellow")
        {
            Destroy(collision.gameObject);
            ScoreManager.instance.Add500Points();
            gameObject.SetActive(false);
        }
    }
}
