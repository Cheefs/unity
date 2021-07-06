using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    const string SCORE_DEFULT_TEXT = "Score:";
    const string LIVES_DEFULT_TEXT = "Lives:";

    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI livesText;

    public bool isGameActive;
    public Button restartButton;

    public Slider volumeSlider;
    public GameObject titleScreen;
    public GameObject pauseScreen;
    private AudioSource audioSource;
    private int score;
    private float spawnRate = 1.0f;
    private int lives = 3;
    private float volume = 0.5f;

    private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = volume;
        volumeSlider.value = volume;
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TooglePause();  
        }
    }

    void TooglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
        pauseScreen.SetActive(isPaused);
    }

    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = $"{SCORE_DEFULT_TEXT}\u00a0{score}";
    }



    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
   
    }

    public void ReastartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficult)
    {
        isGameActive = true;
        spawnRate /= difficult;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        UpdateLives();
        titleScreen.gameObject.SetActive(false);
        GameObject.Find("Music Controls").gameObject.SetActive(false);
    }

    public void DecreaseLives()
    {
        if(isGameActive)
        {
            lives--;
            UpdateLives();
            if (lives == 0)
            {
                GameOver();
            }
        }
    }

    public void UpdateLives()
    {
        if(lives >= 0)
        {
            livesText.text = $"{LIVES_DEFULT_TEXT}\u00a0{lives}";
        }
    }

    public void ChangeVolume(float value)
    {
        audioSource.volume = value;
    }

    private void OnMouseDrag()
    {
        Debug.Log("223");
    }

}
