using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GazeMode
{
    Off, Explicit, Implicit
}

public class GazeManager : MonoBehaviour {
    private static GazeManager instance;
    public static GazeManager Instance { get { return instance; } }

    public GazeMode gazeMode;
    private PlayerGaze[] gazes;

    #region unity callbacks
    private void Awake()
    {
        instance = this;
    }
	void Start () {
        gazes = GetComponentsInChildren<PlayerGaze>();

        //if (gazeMode == GazeMode.Off)
        //{
        //    foreach (PlayerGaze item in gazes)
        //        item.SetModeOff();
        //}
        //else if (gazeMode == GazeMode.Explicit)
        //{
        //    foreach (PlayerGaze item in gazes)
        //        item.SetModeExplicit();
        //}
        //else if (gazeMode == GazeMode.Implicit)
        //{
        //    foreach (PlayerGaze item in gazes)
        //        item.SetModeImplicit();
        //}

        DontDestroyOnLoad(gameObject);
    }
    #endregion

    /// <summary>
    ///
    /// </summary>
    /// <param name="number">starts at 0</param>
    /// <param name="position"></param>
    public void MoveGaze(int number, Vector2 position)
    {
        if (number >= gazes.Length)
            return;

        gazes[number].SetPosition(position);
    }


}
