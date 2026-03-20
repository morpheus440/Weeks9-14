using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BugScript : MonoBehaviour
{
    public float speed = 0f;
    public AnimationCurve animationCurve;
    public float duration;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(MoveBug()); 
    }

    private IEnumerator MoveBug()
    {
        float progress = 0f;
        while (progress < duration)
        {
            progress += Time.deltaTime;
            speed = animationCurve.Evaluate(progress / duration) * 0.1f;
            Vector3 position = transform.position;
            position.x += speed;
            transform.position = position;
            yield return null;
        } 
    }
}
