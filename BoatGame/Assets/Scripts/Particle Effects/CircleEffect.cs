using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CircleEffect : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3 startScale = new Vector3(1, 1, 1);
    public Vector3 endScale;
    public float startAlpha = 1;
    public float endAlpha = 0;
    public float ttl;

    void Start()
    {
        transform.localScale = startScale;
        Color c = GetComponent<SpriteRenderer>().material.color;
        GetComponent<SpriteRenderer>().material.color = new Color(c.r, c.g, c.b, startAlpha);

        transform.DOScale(endScale, ttl);
        GetComponent<SpriteRenderer>().material.DOFade(endAlpha, ttl).OnComplete(DeleteEffect);
    }

    void DeleteEffect()
    {
        Destroy(gameObject);
    }

}
