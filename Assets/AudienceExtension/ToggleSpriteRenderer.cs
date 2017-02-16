using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSpriteRenderer : MonoBehaviour {

    SpriteRenderer gfx;

    // Use this for initialization
    void Start()
    {
        gfx = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            gfx.enabled = !gfx.enabled;
        }
    }
}
