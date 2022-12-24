using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score;
    private int highScore;

    [SerializeField] Text text;
    [SerializeField] Text money;

    void Start()
    {
        SetText();
    }

    private void Update()
    {
        money.text = Money.balance.ToString();
    }

    public void SetText()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        text.text = "HIGH SCORE: " + highScore.ToString();
    }
}
