using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            other.transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            other.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 150f));
            other.transform.GetComponent<Character>().life--;
            if(other.transform.GetComponent<Character>().life <= 0){
                GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }

}
