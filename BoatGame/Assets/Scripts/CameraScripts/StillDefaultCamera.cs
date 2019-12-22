using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StillDefaultCamera : CameraBehaviour
{
    float maxZoom = 0;
    float xLerp = 1;

    public StillDefaultCamera() : base(0)
    {

    }

    public override void DoCameraBehaviour(Transform camera, BoatMovement boat)
    {
        if(boat.speed > 0.5f)
        {
            maxZoom = 3;
        }

        if(maxZoom == 3)
        {
            xLerp = Mathf.Lerp(xLerp, 0, 0.15f * Time.deltaTime);
        }
        base.zoomoutValue = Mathf.Lerp(zoomoutValue, maxZoom, 0.1f * Time.deltaTime);
        Camera.main.orthographicSize = 1f + zoomoutValue;
        float y = Mathf.Clamp(boat.transform.position.y, -4.9f + Camera.main.orthographicSize, 3000f);
        camera.position = new Vector3(boat.transform.position.x * xLerp + 0.3f * (1-xLerp), y, camera.position.z);
    }
}
