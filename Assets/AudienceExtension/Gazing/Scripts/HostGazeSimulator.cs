using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostGazeSimulator : MonoBehaviour {

	void Start () {
        DontDestroyOnLoad(gameObject);
        InvokeRepeating("SimulateGaze", 1, 0.51f);
    }

	void SimulateGaze () {
        GazeManager.Instance.MoveGaze(0, Random.insideUnitCircle * 13);
	}
}
