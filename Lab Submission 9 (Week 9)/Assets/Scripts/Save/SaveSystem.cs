using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;

public static class SaveSystem
{
    public static void SavePlayer(PlayerController player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.json";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData playerData = new PlayerData(player);
        formatter.Serialize(stream, playerData);
        stream.Close();
    }

    public static void SaveScore(ScoreManager scoreManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/score.json";
        FileStream stream = new FileStream(path, FileMode.Create);
        ScoreData scoreData = new ScoreData(scoreManager);
        formatter.Serialize(stream, scoreData);
        stream.Close();
    }

    public static void SaveTargets(RandomTarget randomTarget)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/targets.json";
        FileStream stream = new FileStream(path, FileMode.Create);
        EnemyData enemyData = new EnemyData(randomTarget);
        formatter.Serialize(stream, enemyData);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.json";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData playerData = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return playerData;
        }
        else
        {
            UnityEngine.Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static ScoreData LoadScore()
    {
        string path = Application.persistentDataPath + "/score.json";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            ScoreData scoreData = formatter.Deserialize(stream) as ScoreData;
            stream.Close();
            return scoreData;
        }
        else
        {
            UnityEngine.Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static EnemyData LoadTargets()
    {
        string path = Application.persistentDataPath + "/targets.json";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            EnemyData enemyData = formatter.Deserialize(stream) as EnemyData;
            stream.Close();
            return enemyData;
        }
        else
        {
            UnityEngine.Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
