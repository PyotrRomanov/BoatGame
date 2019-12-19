using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    CameraBehaviour currentBehaviour;

    [SerializeField]
    BoatMovement boatMovement;


    // Start is called before the first frame update
    void Start()
    {
        currentBehaviour = new StillDefaultCamera();
    }

    // Update is called once per frame
    void Update()
    {
        HandleCameraMovement();
        HandleBehaviourSwitch();
    }

    ///<summary>Zooms the camera out depending on the speed of the boat</summary>
    void HandleCameraMovement()
    {
        currentBehaviour.DoCameraBehaviour(transform, boatMovement);
    }

    void HandleBehaviourSwitch()
    {
        if(Camera.main.orthographicSize > 3.6f && currentBehaviour is StillDefaultCamera)
        {
            currentBehaviour = new MovingDefaultCamera();
        }
    }
}
