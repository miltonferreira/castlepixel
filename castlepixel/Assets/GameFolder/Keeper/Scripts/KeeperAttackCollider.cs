using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeeperAttackCollider : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            other.GetComponent<Character>().PlayerDamage(1);   // quantidade de dano que player leva
        }
    }
}
