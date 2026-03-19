using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] spritesInArray;
    public int spirteIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSprite(Sprite newSprite)
    {
        if(spritesInArray.Length == spirteIndex)
        {
            spirteIndex = 0;
        }
        spirteIndex++;
    }
}
