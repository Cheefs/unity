using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalHunger : MonoBehaviour
{
    [SerializeField] Slider hungerSlider;
    [SerializeField] int amountToFeed;
    private int currentFedAmount = 0;
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        hungerSlider.maxValue = amountToFeed;
        hungerSlider.value = currentFedAmount;
        hungerSlider.fillRect.gameObject.SetActive(false);

        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }


    public void FeedAnimal(int count)
    {
        currentFedAmount += count;
        hungerSlider.fillRect.gameObject.SetActive(true);
        hungerSlider.value = currentFedAmount;

        if (currentFedAmount >= amountToFeed)
        {
            gm.UpdateScore(amountToFeed);
            Destroy(gameObject);
        }
    }
}
