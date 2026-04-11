using UnityEngine;
using UnityEngine.InputSystem;

public class CrownAlienScript : MonoBehaviour
{
    public Vector3 earthPostion = new Vector3(0, 0, 0);
    public AnimationCurve curve;
    public float t = 0f;
    public float duration = 7f;
    Vector3 startPosition;

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
        transform.position = Vector3.Lerp(startPosition, earthPostion, t / duration);

        float temp = curve.Evaluate(t);

        Vector3 position = transform.position;
        position.y += temp - 0.5f;
        transform.position = position;
    }

    public int ShipType()
    {
        return (2);
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
