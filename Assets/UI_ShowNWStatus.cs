using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UI_ShowNWStatus : MonoBehaviour {
    NetworkManager nwm;
    Text text;
    // Use this for initialization
    void Start () {
        nwm = FindObjectOfType<NetworkManager>();
        text = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        if (nwm == null)
            return;

        if (nwm.IsClientConnected())
            text.text = "Online";
        else
            text.text = "Offline";
            

	}
}
