using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDefaultCamera : CameraBehaviour
{
    public MovingDefaultCamera() : base(0)
    {

    }

    public override void DoCameraBehaviour(Transform camera, BoatMovement boat)
    {
        base.zoomoutValue = Mathf.Lerp(zoomoutValue, 0.5f * Mathf.Abs(boat.speed), 0.5f * Time.deltaTime);
        Camera.main.orthographicSize = 3.6f + zoomoutValue;
        float x = Mathf.Lerp(camera.position.x, 0.3f, 0.5f * Time.deltaTime);
        float y = Mathf.Clamp(boat.transform.position.y, -4.9f + Camera.main.orthographicSize, 3000f);
        camera.position = new Vector3(x, y, camera.position.z);
    }
}
