using UnityEngine;

public class MoveTriangle : MonoBehaviour
{
    public AnimationCurve curve;
    public Transform target;
    public float duration = 5f;
    Vector3 startPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Update()
    {
        startPosition = transform.position;
        float time = Time.deltaTime;
        float temp = 0f;
        while(temp < duration)
        {
            temp += time;
            Vector3 position = Vector3.Lerp(startPosition, target.position, time);
            transform.position = position + new Vector3(0f, curve.Evaluate(temp / duration), 0f);
        }
    }
}
