using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pole : MonoBehaviour
{

    public Transform spike;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.name.Equals("AttackColider")){
            GetComponent<Animator>().Play("Pole", -1);
            spike.GetComponent<Animator>().Play("Spike", -1);
        }
    }

}
