using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public int minInteval;

    private int counter;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyUp(KeyCode.Space) && counter == 0)
        {
            counter = minInteval;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
        counter = counter > 0 ? --counter : counter;
    }
}
