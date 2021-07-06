using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject gui;
    [SerializeField] TextMeshProUGUI scoreText;
    protected int score = 0;

    private void Start()
    {
        UpdateScore();
    }

    public void UpdateScore()
    {
        score += 1;
        scoreText.SetText($"Score: { score }");
    }
}
