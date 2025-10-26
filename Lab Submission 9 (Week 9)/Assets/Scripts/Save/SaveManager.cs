using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnedPrefabData
{
    public List<Vector3> positions = new List<Vector3>();
    public List<int> prefabIndices = new List<int>();
}

public class SaveManager : MonoBehaviour
{
    private const string SaveKey = "SavedPrefabLocations";

    public static void SaveSpawnedPrefabs(List<GameObject> spawnedPrefabs, GameObject[] prefabsToMatch)
    {
        SpawnedPrefabData data = new SpawnedPrefabData();
        foreach (GameObject go in spawnedPrefabs)
        {
            if (go != null)
            {
                data.positions.Add(go.transform.position);
                int prefabIndex = System.Array.IndexOf(prefabsToMatch, GetPrefabFromInstance(go));
                data.prefabIndices.Add(prefabIndex);
            }
        }

        string jsonData = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(SaveKey, jsonData);
        PlayerPrefs.Save();
        Debug.Log("Saved " + data.positions.Count + " prefab locations.");
    }

    public static void LoadSpawnedPrefabs(RandomTarget randomTargetScript)
    {
        if (PlayerPrefs.HasKey(SaveKey))
        {
            string jsonData = PlayerPrefs.GetString(SaveKey);
            SpawnedPrefabData data = JsonUtility.FromJson<SpawnedPrefabData>(jsonData);
            randomTargetScript.ClearSpawnedPrefabs();
            for (int i = 0; i < data.positions.Count; i++)
            {
                int prefabIndex = data.prefabIndices[i];
                if (prefabIndex >= 0 && prefabIndex < randomTargetScript.prefabs.Length)
                {
                    Vector3 position = data.positions[i];
                    GameObject prefab = randomTargetScript.prefabs[prefabIndex];
                    GameObject newPrefab = Instantiate(prefab, position, Quaternion.identity);
                    randomTargetScript.AddSpawnedPrefab(newPrefab);
                }
            }
            Debug.Log("Loaded " + data.positions.Count + " prefab locations.");
        }
        else
        {
            Debug.Log("No saved data found.");
        }
    }

    private static GameObject GetPrefabFromInstance(GameObject instance)
    {
        return UnityEditor.PrefabUtility.GetCorrespondingObjectFromSource(instance);
    }
}
