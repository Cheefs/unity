using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] protected bool isRunning;
    [SerializeField] protected int lives = 3;
    [SerializeField] protected int score;
    [SerializeField] protected TextMeshProUGUI scoreText;
    [SerializeField] protected TextMeshProUGUI livesText;

    void Start()
    {
        isRunning = true;
        UpdateLives();
        UpdateScore(0);
    }

    public void DecreaseLives()
    {
        if (isRunning)
        {
            lives--;
            UpdateLives();
        }
     
        if(lives < 1)
        {
            isRunning = false;

            Debug.Log("Game Over");
        }
    }

    void UpdateLives()
    {
        livesText.SetText($"Lives: {lives}");
    }

    public void UpdateScore(int count)
    {
        if(isRunning)
        {
            score += count;
            scoreText.SetText($"Score: {score}");
        }
    }

    public bool IsGameRunning()
    {
        return isRunning;
    }
}
