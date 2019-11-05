using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DripSpawner : MonoBehaviour
{
    
    [SerializeField]
    GameObject dot;

    [SerializeField]
    float dir;

    PaddleAnimation paddleAnimation;

    // Start is called before the first frame update
    void Start()
    {
        paddleAnimation = transform.parent.GetComponent<PaddleAnimation>();
        InvokeRepeating("SpawnDots", 0.4f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnDots()
    {
        int r = Random.Range(0, 100);

        if(!paddleAnimation.submerged && r < 30)
        {
            SpawnDot();
        }

    }

    void SpawnDot()
    {
        Transform newDot = Instantiate(dot).transform;
        newDot.transform.position = transform.TransformPoint(transform.localPosition + new Vector3(Random.Range(-0.3f, -0.1f), 0, 0));
        newDot.GetComponent<DripEffect>().dir = new Vector2(0, -0.3f);
        newDot.GetComponent<DripEffect>().spawnPoint = transform;
        newDot.GetComponent<DripEffect>().ttl = 0.2f;
    }
}
