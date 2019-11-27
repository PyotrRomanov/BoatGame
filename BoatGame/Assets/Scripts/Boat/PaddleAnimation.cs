using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleAnimation : MonoBehaviour
{
    /// <summary>rotation value of the current oar, set by BoatMovement script</summary>
    public float rotation;
    public bool submerged {get; private set;}
    
    /// <summary>Determines if this is the left or right oar, equal to either 1 or -1</summary>
    [SerializeField]
    float side;

    // Reference to the point the oar pivots around
    Transform pivot;

    [SerializeField]
    GameObject circle;
    
    void Start()
    {
        pivot = transform.parent;
        submerged = true;
    }

    void Update()
    {
        // Set rotation of the pivot to the right angle using given rotation
        pivot.localRotation = Quaternion.Euler(0, pivot.localEulerAngles.y, HelperMethods.Map(rotation, 0, 1, -70, 70) * side);
    }

#region submerge logic
    public void Submerge()
    {
        submerged = true;
        pivot.localRotation = Quaternion.Euler(0, 45, pivot.localEulerAngles.z);
        circle.SetActive(true);
    }

    public void Unsubmerge()
    {
        submerged = false;
        pivot.localRotation = Quaternion.Euler(0, 0, pivot.localEulerAngles.z);
        circle.SetActive(false);
    }
#endregion
}
