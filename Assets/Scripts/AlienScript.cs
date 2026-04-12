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

    void Start()
    {
        startPosition = transform.position;//set start pos to current pos
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        transform.position = Vector3.Lerp(startPosition, earthPosition, t / duration); //moves twords earth pos

        Vector3 position = transform.position;
        transform.position = position;
    }

    public Vector3 FindObjectTransform()//find tranform of this object
    {
        return (transform.position);
    }

    public void DestroyThisObject()//destorys this object
    {
        Destroy(gameObject);
    }
}
