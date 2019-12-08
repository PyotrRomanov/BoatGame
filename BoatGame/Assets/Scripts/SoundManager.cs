using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource bgm;
    
    [SerializeField]
    AudioClip[] notes = new AudioClip[10];

    // Start is called before the first frame update
    void Start()
    {
        bgm = GetComponent<AudioSource>();
        //notes = transform.GetChild(0).GetComponents<AudioSource>();
        

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
        
        StartCoroutine(PlayNoteFunction());
    }

    IEnumerator PlayNoteFunction()
    {
        AudioSource src = gameObject.AddComponent<AudioSource>();
        src.clip = notes[Random.Range(0, 9)];
        
        src.time = 0.5f;
        src.volume = 0.3f;
        src.Play();
        yield return new WaitForSeconds(3f);
        Destroy(src);
    }
}
