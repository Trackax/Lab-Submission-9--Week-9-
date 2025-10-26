using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RandomTarget : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject[] prefabs;
    public float spawnInterval = 2f;

    private List<GameObject> spawnedObjects = new List<GameObject>();
    private Coroutine spawnCoroutine;

    void Start()
    {
        spawnCoroutine = StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            int randomNum = UnityEngine.Random.Range(0, prefabs.Length);
            GameObject newPrefab = Instantiate(prefabs[randomNum], spawnPoint.transform.position, Quaternion.identity);
            spawnedObjects.Add(newPrefab);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void SaveGame()
    {
        SaveManager.SaveSpawnedPrefabs(spawnedObjects, prefabs);
    }

    public void LoadGame()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
        }
        SaveManager.LoadSpawnedPrefabs(this);
        spawnCoroutine = StartCoroutine(SpawnRoutine());
    }

    public void ClearSpawnedPrefabs()
    {
        foreach (GameObject go in spawnedObjects)
        {
            if (go != null)
            {
                Destroy(go);
            }
        }
        spawnedObjects.Clear();
    }

    public void AddSpawnedPrefab(GameObject go)
    {
        spawnedObjects.Add(go);
    }
}