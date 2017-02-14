using UnityEngine;
using System.Collections;

public class Communicator : MonoBehaviour {
    private static MS_NetworkPlayer player;
    public static MS_NetworkPlayer Player
    {
        get
        {
            if (player != null)
                return player;
            else
                player = GetPlayer();

            return player;
        }
    }

    static MS_NetworkPlayer GetPlayer() {
        MS_NetworkPlayer[] nwp = FindObjectsOfType<MS_NetworkPlayer>();
        foreach (MS_NetworkPlayer item in nwp) {
            if (item.hasAuthority) {
                return item;
            }
        }
        return null;
    }

    void Awake () {
        GetPlayer();
	}
}