using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour
{
    public Color[] colors;

    public SpriteRenderer spriteRenderer;

    void Start()
    {
        int randomColor = Random.Range(0, colors.Length);
        spriteRenderer.color = colors[randomColor];
    }
}
