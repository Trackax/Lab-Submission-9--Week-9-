using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTarget : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject[] prefabs;
    public float spawnInterval = 2f;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
        
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            int randomNum = UnityEngine.Random.Range(0, prefabs.Length);
            Instantiate(prefabs[randomNum], spawnPoint.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
