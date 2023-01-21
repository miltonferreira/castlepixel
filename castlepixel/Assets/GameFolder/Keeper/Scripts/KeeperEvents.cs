using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeeperEvents : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip attackSound;

    public void KeeperAttackSound(){
        audioSource.PlayOneShot(attackSound,0.5f);
    }
}
