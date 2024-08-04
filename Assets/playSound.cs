using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSound : MonoBehaviour
{
    public AudioSource audioSource;

    public void playAudio()
    {
        audioSource.Play();
    }
}
