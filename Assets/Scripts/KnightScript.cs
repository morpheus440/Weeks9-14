using UnityEngine;
using UnityEngine.InputSystem;

public class KnightScript : MonoBehaviour
{
    public AudioSource footstepAudioSource;
    public Animator knightAnimator;
    public float moveSpeed = 5f;
    public float movement;
    float temp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(movement, 0f, 0f) * moveSpeed * Time.deltaTime;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 xMovement = context.ReadValue<Vector2>();
        movement = xMovement.x;

        bool isRunning = temp != 0f;

        knightAnimator.SetBool("isRunning", isRunning);
    }


    public void OnFootStep()
    {
        footstepAudioSource.Play();
    }


}
