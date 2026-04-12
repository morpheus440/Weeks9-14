using UnityEngine;
using UnityEngine.InputSystem;

public class CrownAlienScript : MonoBehaviour
{
    public Vector3 earthPostion = new Vector3(0, 0, 0);
    public AnimationCurve curve;
    public float t = 0f;
    public float duration = 7f;
    Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;//sets current pos
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        transform.position = Vector3.Lerp(startPosition, earthPostion, t / duration);

        float temp = curve.Evaluate(t);

        Vector3 position = transform.position;
        position.y += temp - 0.5f;//moves it with the animation curve -0.5 to put it in the middle since animation curve revolves above the middle line not on it
        transform.position = position;
    }

    public Vector3 FindObjectTransform()//return object pos
    {
        return (transform.position);
    }

    public void DestroyThisObject()//desotry this object
    {
        Destroy(gameObject);
    }
}
