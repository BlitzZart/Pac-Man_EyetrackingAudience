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

        InitGazeMode();

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        ChangeGazeMode();
    }
    #endregion


    #region private
    private void ChangeGazeMode()
    {
        if (Input.GetKey(KeyCode.G))
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                gazeMode = GazeMode.Off;
                InitGazeMode();
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                gazeMode = GazeMode.Explicit;
                InitGazeMode();
            }
            else if (Input.GetKeyDown(KeyCode.I))
            {
                gazeMode = GazeMode.Implicit;
                InitGazeMode();
            }
        }
    }

    private void InitGazeMode()
    {
        if (gazeMode == GazeMode.Off)
        {
            foreach (PlayerGaze item in gazes)
                item.SetModeOff();
        }
        else if (gazeMode == GazeMode.Explicit)
        {
            foreach (PlayerGaze item in gazes)
                item.SetModeExplicit();
        }
        else if (gazeMode == GazeMode.Implicit)
        {
            foreach (PlayerGaze item in gazes)
                item.SetModeImplicit();
        }
    }
    #endregion

    #region public
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
    #endregion
}