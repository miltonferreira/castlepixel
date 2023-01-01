using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{

    public Transform skin;

    public Transform a,b;

    public bool goRight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(goRight){
            skin.localScale = new Vector3(-1f,1f,1f);
            if(Vector2.Distance(transform.position, b.position) < 0.1f){
                //goRight = false;    // inverte para esquerda
                transform.position = a.position;
            }
            transform.position = Vector2.MoveTowards(transform.position, b.position, 0.2f * Time.deltaTime); // vai para direita
        }else{
            skin.localScale = new Vector3(1f,1f,1f);
            if(Vector2.Distance(transform.position, a.position) < 0.1f){
                //goRight = true;    // inverte para direita
                transform.position = b.position;
            }
            transform.position = Vector2.MoveTowards(transform.position, a.position, 0.2f * Time.deltaTime); // vai para esquerda
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            other.GetComponent<Character>().life--;
            this.gameObject.SetActive(false);   // desativa ghost
        }
    }
}
