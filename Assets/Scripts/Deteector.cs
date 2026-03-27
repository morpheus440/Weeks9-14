using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Deteector : MonoBehaviour
{
    public UnityEvent onMover;
    public SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        Vector2 vector2 = context.ReadValue<Vector2>();
        Vector2 worldMousePos = Camera.main.ScreenToWorldPoint(vector2);
        Debug.Log(worldMousePos);
        bool isHovered = spriteRenderer.bounds.Contains(worldMousePos);

        if (isHovered)
        {
            onMover.Invoke();
        }
    }
}
