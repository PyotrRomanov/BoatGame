using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DripEffect : MonoBehaviour
{
    public Vector2 dir;

    public float ttl;
    public Transform spawnPoint;

    [SerializeField]
    AnimationCurve dripCurve;

    [SerializeField]
    GameObject splash;

    SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 movePosition = transform.position + new Vector3(dir.x, dir.y, 0);
        transform.DOMove(movePosition, ttl).SetEase(dripCurve).OnComplete(SpawnSplash);
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    void SpawnSplash()
    {
        GameObject newSplash = Instantiate(splash);
        newSplash.transform.position = transform.position;
        newSplash.GetComponent<CircleEffect>().startScale = new Vector3(0.2f, 0.2f, 1);
        newSplash.GetComponent<CircleEffect>().endScale = new Vector3(0.8f, 0.8f, 1);
        newSplash.GetComponent<CircleEffect>().ttl = 2;
        //soundManager.PlayNote();
        Destroy(gameObject, ttl);
    }
}
