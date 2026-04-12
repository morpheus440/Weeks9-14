using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class TargetScirpt : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float speed = 3f;
    public Vector2 directionalInput;
    public bool canMove = true;
    public float time = 0f;
    public AlienControllerScript alienControllerScript;

    void Start()
    {
        
    }

    void Update()
    {
        time += Time.deltaTime;
        if (canMove)//can move determined if can in reload corrutine
        {
            transform.position += (Vector3)directionalInput * speed * Time.deltaTime;//directional movment
        }
    }

    public void OnMove(InputAction.CallbackContext context)//using unity new input system to move
    {
        directionalInput = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    { 
        if (context.performed)//calls it only once rather then three times
        {
            StartCoroutine(reload());//calls reload coroutine
            GameObject newExplosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);//makes explosion object

            Vector3 topLeft = transform.position + new Vector3(-1.26f, -1.26f, 0);//set top left and bottom right coner to make effected box from attacking
            Vector3 bottemRight = transform.position + new Vector3(1.26f, 1.26f, 0);

            for(int i = alienControllerScript.aliens.Count - 1; i >= 0; i--)//goes through every alien in the list checking if its in the box
            {
                GameObject alien = alienControllerScript.aliens[i];

                Vector3 alienPosition = alien.transform.position;

                if (alienPosition.x >= topLeft.x && alienPosition.x <= bottemRight.x &&
                alienPosition.y >= topLeft.y && alienPosition.y <= bottemRight.y)
                {
                    alienControllerScript.CheckIfCrownAlien(alien);//calls method 
                    alienControllerScript.RemoveAlien(alien);//calls method
                }

            }
        }
    }
    private IEnumerator reload()
    {
        float duration = 1.5f;

        while (time < duration)//sets can move to false when waiting 1.5f
        {
            canMove = false;
            yield return null;
        }

        canMove = true;//lets you move again
        time = 0f;//resets time 
    }
}
