using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    [SerializeField]
    BoatMovement boatMovement;

    float zoomoutValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleCameraMovement();
    }

    ///<summary>Zooms the camera out depending on the speed of the boat</summary>
    void HandleCameraMovement()
    {
        zoomoutValue = Mathf.Lerp(zoomoutValue, 0.2f * Mathf.Abs(boatMovement.speed), 0.5f * Time.deltaTime);
        Camera.main.orthographicSize = 3.6f + zoomoutValue;
        float y = Mathf.Clamp(boatMovement.transform.position.y, -4.9f + Camera.main.orthographicSize, 100f);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}
