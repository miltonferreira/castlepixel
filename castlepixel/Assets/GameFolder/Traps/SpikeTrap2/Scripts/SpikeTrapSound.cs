using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapSound : MonoBehaviour
{
    
    public AudioSource audioSource;
    public AudioClip audioClip;

    
    public void PlaySound(){
        audioSource.PlayOneShot(audioClip);
    }

}
