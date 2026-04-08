using UnityEngine;

public class Explode : MonoBehaviour
{
    float time = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 3f)
        {
            Destroy(gameObject);
        }
    }
}
