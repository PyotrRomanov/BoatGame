using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using InControl;

public class TutorialScreenScript : MonoBehaviour
{
    [SerializeField]
    GameObject boat;
    [SerializeField]
    GameObject blackScreen;

    [SerializeField]
    SoundManager soundManager;

    BoatActions action;

    void Awake()
    {
        boat.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        action = new BoatActions();
        action.StartGame.AddDefaultBinding(Key.Space);
        action.StartGame.AddDefaultBinding(InputControlType.Command);
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice inputDevice = InputManager.ActiveDevice;
        if(action.StartGame.IsPressed)
        {
            StartCoroutine("FadeOut");
        }
    }

    IEnumerator FadeOut()
    {
        GetComponent<SpriteRenderer>().material.DOFade(0, 2);
        yield return new WaitForSeconds(2);
        soundManager.StartPlayingBGM();
        boat.SetActive(true);
        gameObject.SetActive(false);
        blackScreen.GetComponent<SpriteRenderer>().material.DOFade(0, 3);
        yield return new WaitForSeconds(3);
        blackScreen.SetActive(false);
    }
}
