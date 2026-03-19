using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    float moveSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //context.action.ReadValue<Vector2>();
        
    
    }
    public void OnMove(InputAction.CallbackContext context)
    {
       // directionInput = context.ReadValue<Vector2>();
    }
}
