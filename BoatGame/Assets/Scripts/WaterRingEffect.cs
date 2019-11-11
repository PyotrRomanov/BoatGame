using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WaterRingEffect : MonoBehaviour
{
    [SerializeField]
    AnimationCurve curve;

    [SerializeField]
    Vector3 startScale;
    [SerializeField]
    Vector3 endScale;

    // Start is called before the first frame update
    void Start()
    {
        startScale = Vector3.Scale(startScale, transform.localScale);
        endScale = Vector3.Scale(endScale, transform.localScale);
        Enlargen();
    }

    void Enlargen()
    {
        transform.DOScale(endScale, 5).SetEase(curve).OnComplete(Ensmallen);
    }

    void Ensmallen()
    {
        transform.DOScale(startScale, 5).SetEase(curve).OnComplete(Enlargen);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
