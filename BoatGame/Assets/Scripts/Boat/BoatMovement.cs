using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class BoatMovement : MonoBehaviour
{
    BoatActions boatActions;

    // Variables governing the movement and orientation of the boat's hull
    public float speed = 0;
    public float rot = 0;

    // Variables governing the rotation of the oars of the boat
    [SerializeField]
    float r = 0;
    float lastR = 0;

    [SerializeField]
    float l = 0;
    float lastL = 0;

    [SerializeField]
    PaddleAnimation leftPaddle;
    [SerializeField]
    PaddleAnimation rightPaddle;

    float paddleSpeed = 1f;

    // Resistance lowering speed of rotation and movement
    [SerializeField]
    float rotResistance;
    float speedResistance = 0.5f;

    // List of trigger zones the boat is currently in
    List<TriggerEffect> currentlyAffectingTriggers = new List<TriggerEffect>();

    // Start is called before the first frame update
    void Start()
    {
        BindControls();
    }

    void Update()
    {
        ApplyMovement();

        HandleControls();

        MovementLogic();

        ApplyPaddleRotation();

        HandleTriggerEffects();

        HandleResistance();
    }

#region trigger and collision handling
    /// <summary> Triggers are used for zones that affect the boat's behaviour </summary>
    private void OnTriggerEnter2D(Collider2D other) {
        currentlyAffectingTriggers.Add(other.gameObject.GetComponent<TriggerEffect>());
    }

    /// <summary> Triggers are used for zones that affect the boat's behaviour </summary>
    private void OnTriggerExit2D(Collider2D other) {
        
        currentlyAffectingTriggers.Remove(other.gameObject.GetComponent<TriggerEffect>());
    }

    /// <summary> Collision is used for objects that physically block the boat </summary>
    private void OnCollisionEnter2D(Collision2D other) {
        speed = 0;
    }
#endregion


    void ApplyMovement()
    {
        transform.Rotate(0, 0, rot * Time.deltaTime, Space.Self);
        transform.Translate(0, speed * Time.deltaTime, 0, Space.Self);
    }

    void ApplyPaddleRotation()
    {
        leftPaddle.rotation = l;
        rightPaddle.rotation = r;
    }


    void HandleResistance()
    {
        // rotation slowly returns to 0, rounded down when the value is too small
        if(rot > 0)
        {
            rot -= rotResistance * Time.deltaTime;
        }else if(rot < 0)
        {
            rot += rotResistance * Time.deltaTime;
        }
        if(rot < 0.2f && rot > -0.2f)
        {
            rot = 0;
        }

        // Speed slowly returns to 0
        if(speed > 0){
            speed -= speedResistance * Time.deltaTime;
        }else if(speed < 0){
            speed += speedResistance * Time.deltaTime;
        }
    }

    void HandleControls()
    {
        InputDevice inputDevice = InputManager.ActiveDevice;

       if(boatActions.LeftPaddleUp)
       {
           l = Mathf.Clamp(l + paddleSpeed * Time.deltaTime, 0, 1);
       } 

       if(boatActions.LeftPaddleDown)
       {
           l = Mathf.Clamp(l - paddleSpeed * Time.deltaTime, 0, 1);
       }

       if(boatActions.LeftPaddleUnsubmerge.WasPressed)
       {
           leftPaddle.Unsubmerge();
       }
       if(boatActions.LeftPaddleUnsubmerge.WasReleased)
       {
           leftPaddle.Submerge();
       }

       if(boatActions.RightPaddleUp)
       {
           r = Mathf.Clamp(r + paddleSpeed * Time.deltaTime, 0, 1);
       } 

       if(boatActions.RightPaddleDown)
       {
           r = Mathf.Clamp(r - paddleSpeed * Time.deltaTime, 0, 1);
       }

       if(boatActions.RightPaddleUnsubmerge.WasPressed)
       {
           rightPaddle.Unsubmerge();
       }
       if(boatActions.RightPaddleUnsubmerge.WasReleased)
       {
           rightPaddle.Submerge();
       }


    }

    /// <summary> Determines how much should be added to the rot and speed values for next frame </summary>
    void MovementLogic()
    {
        // Find the difference in oar angle for both sides
        float deltaL = lastL - l;
        float deltaR = lastR - r;

        // If the oar/paddle is submerged, apply a certain fraction of the angle difference to the boat's speed and rotation
        if(rightPaddle.submerged){
            speed += deltaR * Time.deltaTime * 100;
            rot += deltaR * Time.deltaTime * 1000;
        }
        if(leftPaddle.submerged){
            speed += deltaL * Time.deltaTime * 100;
            rot -= deltaL * Time.deltaTime * 1000;
        }
        
        // Save current oar angles for computation in the next frame
        lastL = l;
        lastR = r;
    }

    void BindControls()
    {
        boatActions = new BoatActions();

        // Setup keyboard controls
        boatActions.RightPaddleUp.AddDefaultBinding(Key.I);
        boatActions.RightPaddleDown.AddDefaultBinding(Key.N);
        boatActions.RightPaddleUnsubmerge.AddDefaultBinding(Key.J);

        boatActions.LeftPaddleUp.AddDefaultBinding(Key.E);
        boatActions.LeftPaddleDown.AddDefaultBinding(Key.C);
        boatActions.LeftPaddleUnsubmerge.AddDefaultBinding(Key.D);

        // Setup gamepad controls
        boatActions.RightPaddleUp.AddDefaultBinding(InputControlType.RightTrigger);
        boatActions.RightPaddleDown.AddDefaultBinding(InputControlType.RightBumper);
        boatActions.RightPaddleUnsubmerge.AddDefaultBinding(InputControlType.Action1);

        boatActions.LeftPaddleUp.AddDefaultBinding(InputControlType.LeftTrigger);
        boatActions.LeftPaddleDown.AddDefaultBinding(InputControlType.LeftBumper);
        boatActions.LeftPaddleUnsubmerge.AddDefaultBinding(InputControlType.DPadDown);
    }

    /// <summary> Handles all effects caused by triggers that currently affect the boat</summary>
    void HandleTriggerEffects()
    {
        foreach(TriggerEffect te in currentlyAffectingTriggers)
        {
            te.Effect(this);
        }
    }
}
