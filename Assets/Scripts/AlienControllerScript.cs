using UnityEngine;
using System.Collections.Generic;

public class AlienControllerScript : MonoBehaviour
{
    public GameObject alienPrefab;
    public List<AlienScript> aliens = new List<AlienScript>();
    public Vector3 spawnPosition;
    public float timer = 0f;
    public float difficultly = 7f;


    void Start()
    {
        createAlien();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > difficultly)
        {
            if(difficultly > 3)
            {
                difficultly -= 1;
            }
            timer = 0f;
            createAlien();
        }
    }

    public void createAlien()
    {
            int randomSide = Random.Range(0, 4);

            if (randomSide == 0)
            {
                spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Screen.height, 0));
            }
            if (randomSide == 1)
            {
                spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), 0, 0));
            }
            if (randomSide == 2)
            {
                spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(0, Random.Range(0, Screen.height), 0));
            }
            if (randomSide == 3)
            {
                spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Random.Range(0, Screen.height), 0));
            }

            Debug.Log("One");
            GameObject newAlien = Instantiate(alienPrefab, spawnPosition, Quaternion.identity);
    }
}
