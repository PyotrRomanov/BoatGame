using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VortexTriggerEffect : TriggerEffect
{
    public override void Effect(BoatMovement boat)
    {
        Vector3 heading = transform.position - boat.transform.position ;
        float distance = heading.magnitude;
        Vector3 direction = heading / distance;
        
        float angle = HelperMethods.PositiveAngle(HelperMethods.CalculateAngle(boat.transform.position, transform.position)) + 90;
        float currentAngle = HelperMethods.PositiveAngle(boat.transform.rotation.eulerAngles.z);
        
        if(distance > 0.1f)
        {
            boat.transform.Translate(direction * Time.deltaTime * 1 / (distance * 2), Space.World);
                if(Mathf.Abs(Mathf.DeltaAngle(angle, currentAngle)) > 1)
                {
                float angleDir = Mathf.Sin((currentAngle - angle) * Mathf.Deg2Rad);

                if(angleDir < 0)
                {
                    //boat.rot += 30 * Time.deltaTime;
                    boat.transform.Rotate(0, 0, (5 * Time.deltaTime) * (5/(distance + 0.001f)));
                    Debug.Log("Turning left");
                }else if(angleDir > 0)
                {
                    //boat.rot -= 30 * Time.deltaTime;
                    boat.transform.Rotate(0, 0, -(5 * Time.deltaTime) * (5/(distance  + 0.001f)));
                    Debug.Log("Turning right");
                }else
                {
                    boat.rot = 0;
                }
            }
        }else
        {
            
            boat.transform.Rotate(0, 0, 40 * Time.deltaTime);
        }



        

        


    }
}
