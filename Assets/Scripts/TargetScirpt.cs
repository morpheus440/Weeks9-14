using UnityEngine;
using UnityEngine.InputSystem;

public class TargetScirpt : MonoBehaviour
{
    public GameObject alien;
    public float speed = 3f;
    public Vector2 directionalInput;
    
    void Start()
    {
        
    }

    void Update()
    {
        transform.position += (Vector3)directionalInput * speed * Time.deltaTime;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        directionalInput = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Attack!( " + context.phase + " )");
            //alien.DestroyThisObject();
            //Vector3 positionOfAlien = alien.transform.position;
        }
    }
}
