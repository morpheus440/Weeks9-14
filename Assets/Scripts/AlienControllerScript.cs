using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AlienControllerScript : MonoBehaviour
{
    public List<GameObject> aliens = new List<GameObject>();
    public GameObject alienPrefab;
    public GameObject crownAlienPrefab;
    public TextMeshProUGUI scoreCountText;
    //public List<AlienScript> aliens = new List<AlienScript>();
    public Vector3 spawnPosition;
    public float timer = 0f;
    public float timerTwo = 0f;
    public float difficultly = 7f;
    public float crownPoints = 0f;
    public float crownSpawnRate = 15f;

    void Start()
    {

    }
    void Update()
    {
        timer += Time.deltaTime;
        timerTwo += Time.deltaTime;
        if (timer > difficultly)
        {
            if(difficultly > 3)
            {
                difficultly -= 1;
            }
            timer = 0f;
            createAlien();
        }
        if(timerTwo > crownSpawnRate)
        {
            createCrownAlien();
            timerTwo = 0f;
        }
    }

    public void RemoveAlien(GameObject alien)
    {
        AlienScript alienScript = alien.GetComponent<AlienScript>();

        if (alienScript.ShipType() == 2)
        {
            crownPoints += 1;
            scoreCountText.text = "StarCount: " + crownPoints.ToString();
        }

        aliens.Remove(alien);
        Destroy(alien);
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
            aliens.Add(newAlien);
    }

    public void createCrownAlien()
    {
            int randomSide = Random.Range(0, 2);

            if (randomSide == 0)
            {
                spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(0, Random.Range(0, Screen.height), 0));
            }
            if (randomSide == 1)
            {
                spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Random.Range(0, Screen.height) , 0));
        }

        Debug.Log("two");
            GameObject newCrownAlien = Instantiate(crownAlienPrefab, spawnPosition, Quaternion.identity);
            aliens.Add(newCrownAlien);
    }
}
