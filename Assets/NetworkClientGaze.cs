using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GazePlotter))]
public class NetworkClientGaze : MonoBehaviour {
    private GazePlotter gazePlotter;

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        gazePlotter = GetComponent<GazePlotter>();
        gazePlotter.UseFilter = true;
    }

    void Update()
    {
        if (Communicator.Player == null)
            return;

        Communicator.Player.CmdPlayerTowGaze(transform.position);
    }
}
