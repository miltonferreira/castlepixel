using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    public Transform player;

    // Start is called before the first frame update
    void OnEnable(){
        // orientação que fica voltado para player
        player = GameObject.Find("Player").transform;
        transform.right = transform.position - player.position; // sabe onde o player está
    }

    // Update is called once per frame
    void Update(){
        transform.position += transform.right * -20 * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            other.GetComponent<Character>().PlayerDamage(1);
        }
    }

}
