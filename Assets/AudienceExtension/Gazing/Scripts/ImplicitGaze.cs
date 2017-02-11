using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImplicitGaze : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool gaze1, gaze2;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }
    void Update()
    {
        if (gaze1 && gaze2)
            spriteRenderer.enabled = true;
        else
            spriteRenderer.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "GazeOne")
        {
            gaze1 = true;
        }
        else if (collision.tag == "GazeTwo")
        {
            gaze2 = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "GazeOne")
        {
            gaze1 = false;
        }
        else if (collision.tag == "GazeTwo")
        {
            gaze2 = false;
        }
    }
}