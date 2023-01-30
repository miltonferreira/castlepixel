using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pole : MonoBehaviour
{

    public Transform spike;

    public AudioClip sound;

    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.name.Equals("AttackColider")){
            GetComponent<Animator>().Play("Pole", -1);
            spike.GetComponent<Animator>().Play("Spike", -1);
            GetComponent<AudioSource>().PlayOneShot(sound, 0.7f);
        }
    }

}
