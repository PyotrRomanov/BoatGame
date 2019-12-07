using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource bgm;
    AudioSource[] notes;

    // Start is called before the first frame update
    void Start()
    {
        bgm = GetComponent<AudioSource>();
        notes = transform.GetChild(0).GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartPlayingBGM()
    {
        bgm.Play(0);
    }

    public void PlayNote()
    {
        notes[0].Play(0);
    }
}
