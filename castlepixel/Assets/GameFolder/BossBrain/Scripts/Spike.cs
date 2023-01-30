using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{

    Transform boss;

    public AudioClip sound;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy")){
            boss = other.transform;
            other.GetComponent<BossController>().enabled = false;   // desabilita script do boss
            other.transform.parent = transform;
            other.transform.localPosition = Vector3.zero;
        }
    }

    public void CollisionSound(){
        GetComponent<AudioSource>().PlayOneShot(sound, 0.7f);
    }

    // solta boss da lança
    public void ReleaseBoss(){
        if(boss != null){
            boss.GetComponent<BossController>().enabled = true;   // habilita script do boss
            boss.parent = null;
        }
    }
}
