using UnityEngine;
using UnityEngine.InputSystem;

public class CrownAlienScript : MonoBehaviour
{
    //The Third part I will make the yellow alien aswell.
    


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
