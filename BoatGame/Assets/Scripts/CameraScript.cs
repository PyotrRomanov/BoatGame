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
        zoomoutValue = Mathf.Lerp(zoomoutValue, 0.5f * Mathf.Abs(boatMovement.speed), 0.5f * Time.deltaTime);
        Camera.main.orthographicSize = 3.6f + zoomoutValue;
        float y = Mathf.Clamp(boatMovement.transform.position.y, -1.36f, 10f);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}
