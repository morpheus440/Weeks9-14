using TMPro;
using UnityEngine;

public class EarthScript : MonoBehaviour
{
    Vector3 topLeft;
    Vector3 bottemRight;
    public AlienControllerScript alienControllerScript;
    public TextMeshProUGUI scoreCountText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        topLeft = transform.position + new Vector3(-1.26f, -1.26f, 0);//makes new vector3 to determine hitbox of earth
        bottemRight = transform.position + new Vector3(1.26f, 1.26f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = alienControllerScript.aliens.Count - 1; i >= 0; i--)//goes through each alien seeing if its touching each frame
        {
            GameObject alien = alienControllerScript.aliens[i];

            Vector3 alienPosition = alien.transform.position;

            if (alienPosition.x >= topLeft.x && alienPosition.x <= bottemRight.x && 
            alienPosition.y >= topLeft.y && alienPosition.y <= bottemRight.y) //if alien in earth hitbox 
            {
                scoreCountText.text = "You Lose";//set text of textbox
                Destroy(gameObject);//destorys earth
            }
        }
    }
}
