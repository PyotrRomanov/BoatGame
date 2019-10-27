using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleAnimation : MonoBehaviour
{

    public float rotation;
    public bool submerged;
    
    [SerializeField]
    float side;

    Transform pivot;
    // Start is called before the first frame update
    void Start()
    {
        pivot = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        pivot.localRotation = Quaternion.Euler(0, 0, HelperMethods.Map(rotation, 0, 1, -70, 70) * side);
        
    }
}
