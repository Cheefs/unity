using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform starting;
    [SerializeField] float lerpSpeed;
    [SerializeField] GameObject player;
    [SerializeField] GameObject gui;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] float gameSpeed = 30.0f;
    [SerializeField] float dashSPeed = 60.0f;
    protected bool useDash;
    protected int score;

    private void Start()
    {
        UpdateScore(0);
        PlayerController playerController = player.GetComponent<PlayerController>();
        playerController.gameOver = true;
        StartCoroutine(PlayerIntro(playerController));
    }

    IEnumerator PlayerIntro(PlayerController pl)
    {
        Vector3 startPos = pl.transform.position; ;
        Vector3 endPos = starting.position;
        float journeyLength = Vector3.Distance(startPos, endPos);
        float startTime = Time.time;

        float distanceCovered = (Time.time - startTime) * lerpSpeed;
        float fractionOfJourney = distanceCovered / journeyLength;

        pl.GetComponent<Animator>().SetFloat("Speed_Multiplier", 0.5f);

        while(fractionOfJourney < 1)
        {
            distanceCovered = (Time.time - startTime) * lerpSpeed;
            fractionOfJourney = distanceCovered / journeyLength;

            pl.transform.position = Vector3.Lerp(startPos, endPos, fractionOfJourney);
            yield return null;
        }

        pl.GetComponent<Animator>().SetFloat("Speed_Multiplier", 1.0f);
        pl.gameOver = false;
    }

    public void UpdateScore(int obstaclePoints)
    {
        score += useDash ? obstaclePoints * 2 : obstaclePoints;
        scoreText.SetText($"Score: { score }");
    }

    public float GetGameSpeed()
    {
        return useDash ? dashSPeed : gameSpeed;
    }

    public void ToggleDash()
    {
        useDash = !useDash;
    }

    public bool IsDashMode()
    {
        return useDash;
    }
}
