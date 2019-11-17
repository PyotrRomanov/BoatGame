using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class BoatMovement : MonoBehaviour
{
    BoatActions boatActions;
    public float speed = 0;
    public float rot = 0;

    [SerializeField]
    float r = 0;
    float lastR = 0;

    [SerializeField]
    float l = 0;
    float lastL = 0;

    float paddleSpeed = 1f;

    [SerializeField]
    float rotResistance;
    float speedResistance = 0.5f;

    [SerializeField]
    PaddleAnimation leftPaddle;
    [SerializeField]
    PaddleAnimation rightPaddle;

    List<TriggerEffect> currentlyAffectingTriggers = new List<TriggerEffect>();

    // Start is called before the first frame update
    void Start()
    {
        BindControls();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rot * Time.deltaTime, Space.Self);
        transform.Translate(0, speed * Time.deltaTime, 0, Space.Self);
        HandleControls();

        MovementLogic();

        leftPaddle.rotation = l;
        rightPaddle.rotation = r;

        HandleTriggerEffects();

        HandleResistance();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "Vortex")
        {
            currentlyAffectingTriggers.Add(other.gameObject.GetComponent<VortexTriggerEffect>());
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.name == "Vortex")
        {
            currentlyAffectingTriggers.Remove(other.gameObject.GetComponent<VortexTriggerEffect>());
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        speed = 0;
    }

    void HandleResistance()
    {
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

    void MovementLogic()
    {
        float deltaL = lastL - l;
        float deltaR = lastR - r;

        if(rightPaddle.submerged){
            speed += deltaR * Time.deltaTime * 100;
            rot += deltaR * Time.deltaTime * 1000;
        }
        if(leftPaddle.submerged){
            speed += deltaL * Time.deltaTime * 100;
            rot -= deltaL * Time.deltaTime * 1000;
        }
        
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

    void HandleTriggerEffects()
    {
        foreach(TriggerEffect te in currentlyAffectingTriggers)
        {
            te.Effect(this);
        }
    }
}
