using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TrailEffect : MonoBehaviour
{

    public Vector2 dir;

    public float ttl;
    public Transform spawnPoint;
    public float fadeValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 movePosition = spawnPoint.TransformPoint(spawnPoint.localPosition + new Vector3(dir.x, dir.y, 0));
        transform.DOMove(movePosition, ttl);
        GetComponent<SpriteRenderer>().material.DOFade(fadeValue, ttl);
        Destroy(gameObject, ttl);
    }
}
