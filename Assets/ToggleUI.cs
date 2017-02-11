using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ToggleUI : MonoBehaviour {

    NetworkManagerHUD hud;

	// Use this for initialization
	void Start () {
        hud = GetComponent<NetworkManagerHUD>();
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.H)) {
            hud.enabled = !hud.enabled;
        }
	}
}
