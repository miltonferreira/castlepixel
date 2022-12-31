using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy")){
            if(player.GetComponent<PlayerController>().ComboNun == 1f){
                other.GetComponent<Character>().life--;
            }else{
                other.GetComponent<Character>().life-=2;
            }
            
            
        }
    }
}
