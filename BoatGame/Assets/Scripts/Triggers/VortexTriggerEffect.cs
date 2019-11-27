using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VortexTriggerEffect : TriggerEffect
{
    public override void Effect(BoatMovement boat)
    {
        // Calculate relative position and direction to vortex center
        Vector3 heading = transform.position - boat.transform.position;
        float distance = heading.magnitude;
        Vector3 direction = heading / distance;
        
        // Calculate angle from vortex center
        float angle = HelperMethods.PositiveAngle(HelperMethods.CalculateAngle(boat.transform.position, transform.position)) + 90;
        float currentAngle = HelperMethods.PositiveAngle(boat.transform.rotation.eulerAngles.z);
        
        if(distance > 0.1f)
        {
            // Drag boat towards center of vortex with speed depending on distance from vortex
            boat.transform.Translate(direction * Time.deltaTime * 1 / (distance * 2), Space.World);

            // Make sure there is a significant distance between current angle and goal angle
            if(Mathf.Abs(Mathf.DeltaAngle(angle, currentAngle)) > 1)
            {
                // Determine which direction is the fastest to turn in to reach said angle
                float angleDir = Mathf.Sin((currentAngle - angle) * Mathf.Deg2Rad);

                if(angleDir < 0)
                {
                    boat.transform.Rotate(0, 0, (5 * Time.deltaTime) * (5/(distance + 0.001f)));
                    //Debug.Log("Turning left");
                }else if(angleDir > 0)
                {
                    boat.transform.Rotate(0, 0, -(5 * Time.deltaTime) * (5/(distance  + 0.001f)));
                    //Debug.Log("Turning right");
                }else
                {
                    boat.rot = 0;
                }
            }
        }else
        {
            // If the boat is at the center of the vortex, rotate a steady amount
            boat.transform.Rotate(0, 0, 40 * Time.deltaTime);
        }



        

        


    }
}
