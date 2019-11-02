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
    // Start is called before the first frame update
    void Start()
    {
        pivot = transform.parent;
        submerged = true;
    }

    // Update is called once per frame
    void Update()
    {
        pivot.localRotation = Quaternion.Euler(0, pivot.localEulerAngles.y, HelperMethods.Map(rotation, 0, 1, -70, 70) * side);
        
    }

    public void Submerge()
    {
        submerged = true;
        pivot.localRotation = Quaternion.Euler(0, 45, pivot.localEulerAngles.z);
    }

    public void Unsubmerge()
    {
        submerged = false;
        pivot.localRotation = Quaternion.Euler(0, 0, pivot.localEulerAngles.z);
    }
}
