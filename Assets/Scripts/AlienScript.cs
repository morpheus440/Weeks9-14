using UnityEngine;
using UnityEngine.InputSystem;

public class AlienScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 FindObjectTransform()
    {
        return (transform.position);
    }

    public void DestroyThisObject()
    {
        Destroy(gameObject);
    }
}
