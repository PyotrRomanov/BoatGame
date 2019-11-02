using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailSpawner : MonoBehaviour
{

    [SerializeField]
    GameObject dot;

    [SerializeField]
    float dir;

    BoatMovement boatMovement;

    // Start is called before the first frame update
    void Start()
    {
        boatMovement = transform.parent.GetComponent<BoatMovement>();
        InvokeRepeating("SpawnDot", 0.2f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnDot()
    {
        if(boatMovement.speed > 0.1 || boatMovement.speed < -0.1)
        {
            Transform newDot = Instantiate(dot).transform;
            newDot.transform.position = transform.position;
            newDot.GetComponent<TrailEffect>().dir = dir * boatMovement.speed;
            newDot.GetComponent<TrailEffect>().spawnPoint = transform;
        }

    }
}
