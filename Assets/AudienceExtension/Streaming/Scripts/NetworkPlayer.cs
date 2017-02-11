using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[NetworkSettings(channel = 2, sendInterval = 0.033333f)]
public class NetworkPlayer : NetworkBehaviour {

    #region unity callbacks
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
    }
    #endregion

    public void DebugByteStream(byte[] image)
    {
        RenderBytes.Instance.Render(image);
    }

    [ClientRpc(channel = 2)]
    public void RpcSendByteStream(byte[] image)
    {    
        if (isServer)
            return;
        RenderBytes.Instance.Render(image);
    }

    [Command]
    public void CmdPlayerTowGaze(Vector2 position)
    {
        if (!isServer)
            return;

        GazeManager.Instance.MoveGaze(1, position);
    }

}
