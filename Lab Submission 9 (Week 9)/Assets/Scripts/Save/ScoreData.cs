using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class ScoreData
{
    public int highScore;

    public ScoreData(ScoreManager scoreManager)
    {
        highScore = scoreManager.score;
    }
}
