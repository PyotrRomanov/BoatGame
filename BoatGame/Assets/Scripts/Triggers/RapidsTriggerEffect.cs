using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidsTriggerEffect : TriggerEffect
{
    [SerializeField]
    float strength;

    public void Start()
    {
        ParticleSystem.MainModule main = transform.Find("Particles").GetComponent<ParticleSystem>().main;
        main.startSpeed = strength * 2;
    }

    public override void Effect(BoatMovement boat)
    {
        float angle;
        float currentAngle = HelperMethods.PositiveAngle(boat.transform.rotation.eulerAngles.z);
        float rapidsAngle = HelperMethods.PositiveAngle(transform.rotation.eulerAngles.z);

        // Two angles: 0 for up and 180 for down
        float upDistance = Mathf.Abs(Mathf.DeltaAngle(currentAngle, rapidsAngle));
        float downDistance = Mathf.Abs(Mathf.DeltaAngle(currentAngle, rapidsAngle + 180));

        // Determine which way the boat should face
        if(upDistance > downDistance)
        {
            angle = rapidsAngle + 180;
        }else
        {
            angle = rapidsAngle;
        }

        // Make sure there is a significant distance between current angle and goal angle
        float deltaAngle = Mathf.Abs(Mathf.DeltaAngle(angle, currentAngle));
        if(deltaAngle > 1)
        {
            // Determine which direction is the fastest to turn in to reach said angle
            float angleDir = Mathf.Sin((currentAngle - angle) * Mathf.Deg2Rad);
            if(angleDir < 0)
            {
                boat.transform.Rotate(0, 0, strength * (10 * Time.deltaTime) );
                //Debug.Log("Turning left");
            }else if(angleDir > 0)
            {
                boat.transform.Rotate(0, 0, strength * -(10 * Time.deltaTime));
                //Debug.Log("Turning right");
            }else
            {
                boat.rot = 0;
            }
        }
        
        // Add speed to boat in the right direction, depending on how much the boat is facing in that direction
        if(upDistance > downDistance)
        {
            boat.speed -= strength * (90 - deltaAngle)/90 * Time.deltaTime;
        }else
        {
            boat.speed += strength * (90 - deltaAngle)/90 * Time.deltaTime;
        }
    }
}
