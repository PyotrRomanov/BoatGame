using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WaterRingEffect : MonoBehaviour
{
    [SerializeField]
    AnimationCurve curve;

    // Start is called before the first frame update
    void Start()
    {
        Enlargen();
    }

    void Enlargen()
    {
        transform.DOScale(new Vector3(0.8f, 0.8f, 1), 5).SetEase(curve).OnComplete(Ensmallen);
    }

    void Ensmallen()
    {
        transform.DOScale(new Vector3(1.2f, 1.2f, 1), 5).SetEase(curve).OnComplete(Enlargen);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
