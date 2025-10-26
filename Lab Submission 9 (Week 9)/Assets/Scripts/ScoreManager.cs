using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TMP_Text scoreText;

    int score = 0;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        scoreText.text = "SCORE: " + score.ToString();
    }

    public void Add100Points()
    {
        score += 100;
        scoreText.text = "SCORE: " + score.ToString();
    }

    public void Add300Points()
    {
        score += 300;
        scoreText.text = "SCORE: " + score.ToString();
    }

    public void Add500Points()
    {
        score += 500;
        scoreText.text = "SCORE: " + score.ToString();
    }
}
