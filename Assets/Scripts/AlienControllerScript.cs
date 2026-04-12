using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AlienControllerScript : MonoBehaviour
{
    public List<GameObject> aliens = new List<GameObject>();//list of aliens
    public GameObject alienPrefab;
    public GameObject crownAlienPrefab;
    public TextMeshProUGUI scoreCountText;
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
        if (timer > difficultly)//starts at 7 between each spawn, reduces by one each time
        {
            if(difficultly > 3)//at three stop reducing
            {
                difficultly -= 1;
            }
            timer = 0f;
            createAlien();
        }
        if(timerTwo > crownSpawnRate)
        {
            createCrownAlien();
            timerTwo = 0f;//timer two spawns a alien every 15 
        }
    }

    public void RemoveAlien(GameObject alien)
    {
        aliens.Remove(alien);//removes alien from the list
        Destroy(alien);//destroys that game object
    }

    public void CheckIfCrownAlien(GameObject alien)
    {
        if (alien.GetComponent<CrownAlienScript>() != null)//if the object doesnt have the CrownAlienScript it returns with nothing
        {
            crownPoints++;//if it has the script, its the crown ship so it adds to points
            scoreCountText.text = "StarCount: " + crownPoints.ToString();//change text box to add on the starcount
        }
        else
        {
            return;
        }
    }

    public void createAlien()
    {
            int randomSide = Random.Range(0, 4);//random for each edge of screen
                //picks a random side so it can come from any angle
            if (randomSide == 0)
            {//top edge of screen 
                spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Screen.height, 0));
            }
            if (randomSide == 1)
            {//bottom edge of screen
                spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), 0, 0));
            }
            if (randomSide == 2)
            {//left edge of screen
                spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(0, Random.Range(0, Screen.height), 0));
            }
            if (randomSide == 3)
            {//right edge of screen
                spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Random.Range(0, Screen.height), 0));
            }

            GameObject newAlien = Instantiate(alienPrefab, spawnPosition, Quaternion.identity);//spawn alien
            aliens.Add(newAlien);//add alien to list
    }

    public void createCrownAlien()
    {
            int randomSide = Random.Range(0, 2);//either left or right side 
        //only comes from left or right because its position.y being changed with the animationcurve
            if (randomSide == 0)
            {//left side of screen
                spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(0, Random.Range(0, Screen.height), 0));
            }
            if (randomSide == 1)
            {//right side of screen
                spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Random.Range(0, Screen.height) , 0));
        }

            GameObject newCrownAlien = Instantiate(crownAlienPrefab, spawnPosition, Quaternion.identity);//spawn crown alien
            aliens.Add(newCrownAlien);//add crown alien to list
    }
}
