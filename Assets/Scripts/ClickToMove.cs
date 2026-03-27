using System.Collections;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickToMove : MonoBehaviour
{ 
    public AnimationCurve moveCurve;
    bool clicked = true;
    public float moveSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveToCursor();
    }

    public IEnumerator MoveToCursor()
    {

        if(!clicked)
        {
            yield return null;
        }
        Vector3 startPosition = transform.position;
        Vector3 mousePosition = Mouse.current.position.ReadValue();
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        for (int i = 0; i < 10; i++)
        {
            Vector3 position = Vector3.Lerp(startPosition, worldMousePosition, i * 0.1f);
            transform.position = position;

            if(startPosition == worldMousePosition)
            {
                clicked = false;
            }

            yield return null;
        }
    }

    public void SetClick()
    {
        clicked = true;
    }
}
