using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour
{

    public Restart restart;
    public AudioClip audio11;
    public AudioClip audio12;
    public AudioClip audio13;
    public AudioClip audio14;
    public AudioClip audio15;

    public AudioClip[] audioAll = new AudioClip[10];

    public AudioSource audioSource;
    public AudioSource audioEvent;
    public AudioSource audioEvent2;
    public AudioSource audioEvent3;
    public AudioSource audioEvent4;

    public InputGetter inputGetter;

    public PlayerMovement Player;

    int current = 0;
    bool nowExplosion = false;
    bool playingRCS = false;
    bool playingOHMS = false;
    bool shouldPlayRCS = false;
    bool shouldPlayOHMS = false;
    bool looping = false;

    private int currentClipIndex = 0;

    void Start()
    {
        if (audioAll.Length > 0)
        {
            PlayNextClip();
        }
    }

    void PlayNextClip()
    {
        if (currentClipIndex >= audioAll.Length)
        {
            currentClipIndex = 0;
        }

        audioSource.clip = audioAll[currentClipIndex];
        audioSource.Play();
        currentClipIndex++;

        Invoke("PlayNextClip", audioSource.clip.length);
    }


    // Update is called once per frame
    void Update()
    {
        if (restart.explosions && !nowExplosion)
        {
            audioEvent.clip = audio11;
            audioEvent2.clip = audio12;

            audioEvent.PlayOneShot(audio11);
            audioEvent2.PlayOneShot(audio12);
            nowExplosion = true;
        }
        if (!restart.explosions)
        {
            nowExplosion = false;

        }

        shouldPlayRCS = false;
        if (Mathf.Abs(inputGetter.rotationX) != 0.0 || Mathf.Abs(inputGetter.rotationY) != 0.0 || Mathf.Abs(inputGetter.rotationZ) != 0.0)
        {
            shouldPlayRCS = true;
        }

        if (audioEvent3.isPlaying)
        {

            if (shouldPlayRCS == false) {

                audioEvent3.Stop();
            }
        }
        else
        {
            playingRCS = false;
            if (shouldPlayRCS == true)
            {
                audioEvent3.PlayOneShot(audio13);
                playingRCS = true;
            }

        }

        /////// OHMS
        shouldPlayOHMS = false;
        if ((Mathf.Abs(Player.movement[0]) + Mathf.Abs(Player.movement[1]) + Mathf.Abs(Player.movement[2])) > 5.0)
        {
            shouldPlayOHMS = true;
        }
        if (looping && !shouldPlayOHMS) {
            audioEvent4.Stop();
            looping = false;
        }


        if (audioEvent4.isPlaying)
        {

            if (shouldPlayOHMS == false)
            {
                audioEvent4.Stop();
                looping = false;
            }
        }
        else
        {
            if (!looping)
            {
                if (shouldPlayOHMS == true) {
                    audioEvent4.PlayOneShot(audio14);
                    looping = true;
                }
            }
            else
            {
                audioEvent4.clip = audio15;
                audioEvent4.Play();
            }
        }


        
    }




}
