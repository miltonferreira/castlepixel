using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{

    [Header("Velocidade Movimento")]
    public float speedMove;

    public Transform skin;

    public Transform a,b;

    public bool goRight;

    // Update is called once per frame
    void Update()
    {
        if(goRight){
            skin.localScale = new Vector3(-1f,1f,1f);
            if(Vector2.Distance(transform.position, b.position) < 0.1f){
                //goRight = false;    // inverte para esquerda
                transform.position = a.position;
            }
            transform.position = Vector2.MoveTowards(transform.position, b.position, speedMove * Time.deltaTime); // vai para direita
        }else{
            skin.localScale = new Vector3(1f,1f,1f);
            if(Vector2.Distance(transform.position, a.position) < 0.1f){
                //goRight = true;    // inverte para direita
                transform.position = b.position;
            }
            transform.position = Vector2.MoveTowards(transform.position, a.position, speedMove * Time.deltaTime); // vai para esquerda
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            other.GetComponent<Character>().PlayerDamage(1);    // quantidade de dano que player leva
            this.gameObject.SetActive(false);                   // desativa ghost
        }
    }
}
