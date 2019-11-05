using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleAnimation : MonoBehaviour
{

    public float rotation;
    public bool submerged {get; private set;}
    
    [SerializeField]
    float side;

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
        pivot.localRotation = Quaternion.Euler(0, pivot.localEulerAngles.y, HelperMethods.Map(rotation, 0, 1, -70, 70) * side);
    }

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
}
