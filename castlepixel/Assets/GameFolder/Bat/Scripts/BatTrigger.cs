using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatTrigger : MonoBehaviour
{

    public Transform[] bats;

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
            foreach(Transform bat in bats){
                bat.GetComponent<BatController>().enabled = true;
            }
        }
    }
}
