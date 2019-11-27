using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/** <summary>
Abstract class that all zone triggers that affect the boat should inherit. 
</summary> **/
public abstract class TriggerEffect : MonoBehaviour
{
    /// <summary>Function that describes how the trigger affects the boat</summary>
    public abstract void Effect(BoatMovement boat);
}
