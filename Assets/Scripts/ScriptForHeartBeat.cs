using UnityEngine;
using UnityEngine.UIElements;

public class ScriptForHeartBeat : MonoBehaviour
{
    public AnimationCurve curve;
    public Transform target;
    public float speed;
    public float screenWidth = 8f;
    public float t = 0f;
    public float duration = 5f;
    Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        t += Time.deltaTime;
        transform.position = Vector3.Lerp(startPosition, target.position, t / duration);

        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;

        if(pos.x > screenWidth)
        {
            pos.x = screenWidth;
        }

        float temp = curve.Evaluate(t);

        Vector3 position = transform.position;
        position.y += temp - 0.5f;
        transform.position = position;
    }
}