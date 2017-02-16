using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleUIGraphics : MonoBehaviour {


    MaskableGraphic uiElement;

    // Use this for initialization
    void Start()
    {
        uiElement = GetComponent<MaskableGraphic>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            uiElement.enabled = !uiElement.enabled;
        }
    }
}
