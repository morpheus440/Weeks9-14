using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class AlienScript : MonoBehaviour
{
    public AnimationCurve curve;
    public Vector3 earthPosition = new Vector3(0, 0, 0);
    public float duration = 3f;
    Vector3 startPosition;
    float t = 0f;
    //Make two types of ships, one thats yellow and moves in a curving line 
    //the yellow ships gives you a star, you need three stars to win
    //yellow ships come every 15 seconds

    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        transform.position = Vector3.Lerp(startPosition, earthPosition, t / duration);

        float temp = curve.Evaluate(t);

        Vector3 position = transform.position;
        transform.position = position;
    }

    public int ShipType()
    {
        return (1);
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
