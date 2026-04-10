using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class AlienScript : MonoBehaviour
{

    //Make two types of ships, one thats yellow and moves in a curving line 
    //the yellow ships gives you a star, you need three stars to win
    //yellow ships come every 15 seconds

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
