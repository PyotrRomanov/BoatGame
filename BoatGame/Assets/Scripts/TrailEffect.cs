using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TrailEffect : MonoBehaviour
{

    public float dir;
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 movePosition = spawnPoint.TransformPoint(spawnPoint.localPosition + new Vector3(dir, 0, 0));
        transform.DOMove(movePosition, 4);
        GetComponent<SpriteRenderer>().material.DOFade(0, 4);
        Destroy(gameObject, 4);
    }
}
