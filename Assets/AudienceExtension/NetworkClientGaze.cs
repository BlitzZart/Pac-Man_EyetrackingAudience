using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GazePlotter))]
public class NetworkClientGaze : MonoBehaviour {
    private static NetworkClientGaze instance;
    public static NetworkClientGaze Instance { get { return instance; } }

    // scaling defines the ratio between the screen
    // - which shows the game and 
    // - the screen of the notebook on which the eyetracker is attached
    // e.g 24 / 17.4 = 1.37931
    //public float scaling = 1;
    //private float scaleStep = 0.02f;

    private GazePlotter gazePlotter;

    public Transform debugGraphic;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        gazePlotter = GetComponent<GazePlotter>();
        gazePlotter.UseFilter = true;
    }

    void Update()
    {
        //SetScaling();

        debugGraphic.position = transform.position;
        
        if (Communicator.Player == null)
            return;

        Communicator.Player.CmdPlayerTowGaze(transform.position);

    }

    private void SetScaling()
    {
        if (Input.GetKeyDown(KeyCode.Plus) || Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            //scaling += scaleStep;
        }
        else if (Input.GetKeyDown(KeyCode.Minus) || Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            //scaling -= scaleStep;
        }
    }
}
