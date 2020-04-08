using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomOrb : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;
    public int currentSprite;

    void ChangeSprite()
    {
        spriteRenderer.sprite = spriteArray[currentSprite];
        currentSprite++;

        if (currentSprite >= spriteArray.Length)
        {
            currentSprite = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ChangeSprite();
    }
}
