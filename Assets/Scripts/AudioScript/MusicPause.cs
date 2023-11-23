using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPause : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // Jouer le son au démarrage
        audioSource.Play();
    }

    void Update()
    {
        // Exemple de pause du son avec un appui sur l'écran
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            if (touch.phase == TouchPhase.Began)
            {
                if (audioSource.isPlaying)
                    audioSource.Pause();
                else
                    audioSource.UnPause();
            }
        }
    }
}