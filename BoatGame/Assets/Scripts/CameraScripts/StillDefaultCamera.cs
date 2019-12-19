using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StillDefaultCamera : CameraBehaviour
{
    public StillDefaultCamera() : base(0)
    {

    }

    public override void DoCameraBehaviour(Transform camera, BoatMovement boat)
    {
        base.zoomoutValue = Mathf.Lerp(zoomoutValue, 1.5f * Mathf.Abs(boat.speed), 0.3f * Time.deltaTime);
        Camera.main.orthographicSize = 1f + zoomoutValue;
        float y = Mathf.Clamp(boat.transform.position.y, -4.9f + Camera.main.orthographicSize, 3000f);
        camera.position = new Vector3(boat.transform.position.x, y, camera.position.z);
    }
}
