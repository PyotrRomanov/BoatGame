using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{

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
    float resistance = 0.05f;

    [SerializeField]
    PaddleAnimation leftPaddle;
    [SerializeField]
    PaddleAnimation rightPaddle;

    // Start is called before the first frame update
    void Start()
    {
        
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

        HandleResistance();
    }

    void HandleResistance()
    {
        if(rot > 0)
        {
            rot -= resistance;
        }
        if(rot < 0)
        {
            rot += resistance;
        }
        if(rot < 1 && rot > -1)
        {
            rot = 0;
        }

        /*if(speed > 0){
            speed -= resistance;
        }else if(speed < 0){
            speed += resistance;
        }*/
    }

    void HandleControls()
    {
        leftPaddle.submerged = true;
        rightPaddle.submerged = true;

       if(Input.GetKey("e"))
       {
           l = Mathf.Clamp(l + paddleSpeed * Time.deltaTime, 0, 1);
       } 

       if(Input.GetKey("c"))
       {
           l = Mathf.Clamp(l - paddleSpeed * Time.deltaTime, 0, 1);
       }

       if(Input.GetKey("d"))
       {
           leftPaddle.submerged = false;
       }

       if(Input.GetKey("i"))
       {
           r = Mathf.Clamp(r + paddleSpeed * Time.deltaTime, 0, 1);
       } 

       if(Input.GetKey("n"))
       {
           r = Mathf.Clamp(r - paddleSpeed * Time.deltaTime, 0, 1);
       }

       if(Input.GetKey("j"))
       {
           rightPaddle.submerged = false;
       }

    }

    void MovementLogic()
    {
        float deltaL = lastL - l;
        float deltaR = lastR - r;

        if(rightPaddle.submerged){
            speed += deltaR * Time.deltaTime * 100;
            rot += deltaR * 10;
        }
        if(leftPaddle.submerged){
            speed += deltaL * Time.deltaTime * 100;
            rot -= deltaL * 10;
        }
        
        lastL = l;
        lastR = r;
    }
}
