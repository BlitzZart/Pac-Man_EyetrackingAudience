using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImplicitGaze : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool gaze1, gaze2;

    public bool bothGazes = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }
    void Update()
    {
        if (gaze1 && gaze2)
        {
            bothGazes = true;
            spriteRenderer.enabled = true;
        } else
        {
            bothGazes = false;
            spriteRenderer.enabled = false;
        }

        //if (GazeManager.Instance.gazeMode != GazeMode.Implicit)
        //    spriteRenderer.enabled = false;
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

    public void TurnRendererOff()
    {
        spriteRenderer.enabled = false;
    }
}