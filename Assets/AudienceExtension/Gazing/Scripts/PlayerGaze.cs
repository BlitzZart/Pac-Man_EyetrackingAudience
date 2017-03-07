using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGaze : MonoBehaviour {
    private GazeManager gazeManager;
    private GazePlotter gazePlotter;
    private Vector2 targetPosition;
    private float lerpSpeed = 13;


    private SpriteRenderer gazeImageRenderer;
    public Sprite circle, dot;

    #region unity callbacks
    void Start () {
        gazeManager = GazeManager.Instance;
        gazePlotter = GetComponent<GazePlotter>();
        gazeImageRenderer = GetComponent<SpriteRenderer>();

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
        gazeImageRenderer.sprite = circle;
        SetCollider(false);
        SetRenderer(true);
    }
    public void SetModeImplicit()
    {
        gazeImageRenderer.sprite = dot;
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
        //print("turn " + name + " " +  value);
        if (r != null)
            r.enabled = value;
    }
    #endregion

    void OnTriggerStay2D(Collider2D collider)
    {
        ImplicitGaze ig = collider.gameObject.GetComponent<ImplicitGaze>();
        if (ig == null || !ig.bothGazes)
        {
            SetRenderer(false);
            return;
        }

        SetRenderer(true);
    }


    void OnTriggerExit2D(Collider2D collider)
    {
        SetRenderer(false);
    }
}
