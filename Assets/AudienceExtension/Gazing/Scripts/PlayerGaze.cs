using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGaze : MonoBehaviour {
    private GazeManager gazeManager;
    private GazePlotter gazePlotter;
    private Vector2 targetPosition;
    private float lerpSpeed = 13;

    #region unity callbacks
    void Start () {
        gazeManager = GazeManager.Instance;
        gazePlotter = GetComponent<GazePlotter>();

        // is null at player 2 (gaze data is streamed via network)
        if (gazePlotter != null)
            gazePlotter.UseFilter = true;
    }
    void Update()
    {
        // is null at player 2 (gaze data is streamed via network)
        if (gazePlotter == null)
        {
            //print("update");
            transform.position = Vector3.Lerp(transform.position, targetPosition, lerpSpeed * Time.deltaTime);
        }
    }
    #endregion

    #region public
    // this is only used by player 2 (gaze data is streamed via network)
    public void SetPosition(Vector2 position)
    {

        //print("set position");
        // using offset because camera in game scene is off center
        targetPosition = position + new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y);
        //transform.position = position + new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y);
        //Debug.LogError("EYE " + position + "\nOWN " + transform.position);
    }

    public void SetModeOff()
    {
        SetCollider(false);
        SetRenderer(false);
    }
    public void SetModeExplicit()
    {
        SetCollider(false);
        SetRenderer(true);
    }
    public void SetModeImplicit()
    {
        SetCollider(true);
        SetRenderer(false);
    }
    #endregion

    #region private
    private void SetCollider(bool value)
    {
        Collider2D c = GetComponent<Collider2D>();
        if (c != null)
            c.enabled = value;
    }
    private void SetRenderer(bool value)
    {
        SpriteRenderer r = GetComponent<SpriteRenderer>();
        if (r != null)
            r.enabled = value;
    }
    #endregion
}
