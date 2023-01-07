using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bearTrap : MonoBehaviour
{

    Transform player;
    public Transform skin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){

            // ações da bearTrap -----------------------------------
            skin.GetComponent<Animator>().Play("Stuck", -1);
            GetComponent<BoxCollider2D>().enabled = false;

            // ações do Player -----------------------------------
            player = other.transform;

            player.position = transform.position;
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            player.GetComponent<PlayerController>().enabled = false;
            player.GetComponent<PlayerController>().skin.GetComponent<Animator>().SetBool("PlayerRun", false);
            player.GetComponent<PlayerController>().skin.GetComponent<Animator>().Play("PlayerIdle", -1);
            
            Invoke("ReleasePlayer", 2f);
        }
    }

    void ReleasePlayer(){
        player.GetComponent<PlayerController>().enabled = true;
    }
}