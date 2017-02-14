using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

//[NetworkSettings(channel = 2, sendInterval = 0.033333f)]
public class MS_NetworkPlayer : NetworkBehaviour {

    #region unity callbacks
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    [Command]
    public void CmdPlayerTowGaze(Vector2 position)
    {
        if (!isServer)
            return;

        GazeManager.Instance.MoveGaze(1, position);
    }
}
