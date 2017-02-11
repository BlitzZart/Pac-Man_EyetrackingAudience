using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientGazeSimulator : MonoBehaviour {
    
	void Start () {
        DontDestroyOnLoad(gameObject);
        InvokeRepeating("SimulateGaze", 1, 0.73f);
    }

	void SimulateGaze() {
        if (Communicator.Player == null)
            return;

        Communicator.Player.CmdPlayerTowGaze(Random.insideUnitCircle * 17);
	}
}
