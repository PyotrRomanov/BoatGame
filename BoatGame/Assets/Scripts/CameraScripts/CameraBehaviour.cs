using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CameraBehaviour
{
    public float zoomoutValue;

    protected CameraBehaviour(float zoomoutValue)
    {
        this.zoomoutValue = zoomoutValue;
    }

    public abstract void DoCameraBehaviour(Transform camera, BoatMovement boat);
}
