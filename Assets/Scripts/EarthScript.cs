using TMPro;
using UnityEngine;

public class EarthScript : MonoBehaviour
{
    Vector3 topLeft;
    Vector3 bottemRight;
    public AlienControllerScript alienControllerScript;
    public TextMeshProUGUI scoreCountText;
    public bool lost = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        topLeft = transform.position + new Vector3(-1.26f, -1.26f, 0);
        bottemRight = transform.position + new Vector3(1.26f, 1.26f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (lost)
        {
            scoreCountText.text = "You Lose";
        }
        for (int i = alienControllerScript.aliens.Count - 1; i >= 0; i--)
        {
            GameObject alien = alienControllerScript.aliens[i];

            Vector3 alienPosition = alien.transform.position;

            if (alienPosition.x >= topLeft.x && alienPosition.x <= bottemRight.x &&
            alienPosition.y >= topLeft.y && alienPosition.y <= bottemRight.y)
            {
                lost = true;
                Destroy(gameObject);
            }
        }
    }
}
