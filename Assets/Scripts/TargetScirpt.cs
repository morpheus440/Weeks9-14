using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class TargetScirpt : MonoBehaviour
{
    public GameObject alien;
    public GameObject explosionPrefab;
    public float speed = 3f;
    public Vector2 directionalInput;
    public bool canMove = true;
    public float time = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        time += Time.deltaTime;
        if (canMove)
        {
            transform.position += (Vector3)directionalInput * speed * Time.deltaTime;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        directionalInput = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    { 
        if (context.performed)
        {
            StartCoroutine(reload());
            GameObject newExplosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            AlienScript alienScript = alien.GetComponent<AlienScript>();
            Vector3 alienPosition = alienScript.FindObjectTransform();
            //Debug.Log(alienPosition);

            Vector3 topLeft = transform.position + new Vector3(-1.26f, -1.26f, 0);
            Vector3 bottemRight = transform.position + new Vector3(1.26f, 1.26f, 0);

            
            if (alienPosition.x >= topLeft.x && alienPosition.x <= bottemRight.x &&
                alienPosition.y >= topLeft.y && alienPosition.y <= bottemRight.y)
            {
                alienScript.DestroyThisObject();
            }
        }
    }
    private IEnumerator reload()
    {
        float duration = 1.5f;

        while (time < duration)
        {
            canMove = false;
            yield return null;
        }

        canMove = true;
        time = 0f;
    }
}
