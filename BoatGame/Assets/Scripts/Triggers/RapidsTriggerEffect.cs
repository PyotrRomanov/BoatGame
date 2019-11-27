using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidsTriggerEffect : TriggerEffect
{
    public override void Effect(BoatMovement boat)
    {
        float angle;
        float currentAngle = HelperMethods.PositiveAngle(boat.transform.rotation.eulerAngles.z);

        // Two angles: 0 for up and 180 for down
        float upDistance = Mathf.Abs(Mathf.DeltaAngle(currentAngle, 0));
        float downDistance = Mathf.Abs(Mathf.DeltaAngle(currentAngle, 180));

        // Determine which way the boat should face
        if(upDistance > downDistance)
        {
            angle = 180;
        }else
        {
            angle = 0;
        }

        // Make sure there is a significant distance between current angle and goal angle
        if(Mathf.Abs(Mathf.DeltaAngle(angle, currentAngle)) > 1)
        {
            // Determine which direction is the fastest to turn in to reach said angle
            float angleDir = Mathf.Sin((currentAngle - angle) * Mathf.Deg2Rad);
            if(angleDir < 0)
            {
                boat.transform.Rotate(0, 0, (10 * Time.deltaTime) );
                //Debug.Log("Turning left");
            }else if(angleDir > 0)
            {
                boat.transform.Rotate(0, 0, -(10 * Time.deltaTime));
                //Debug.Log("Turning right");
            }else
            {
                boat.rot = 0;
            }
        }
    }
}
