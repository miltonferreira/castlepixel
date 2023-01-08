using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeeperController : MonoBehaviour
{

    [Header("Velocidade Movimento")]
    public float speedMove;

    public Transform skin;
    public Transform keeperRange;

    public Transform a;
    public Transform b;

    public bool goRight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // desativa este script --------------------------------------------------------------------
        if(GetComponent<Character>().life <= 0){
            keeperRange.GetComponent<CircleCollider2D>().enabled = false;    // desativa colisor de range
            GetComponent<CapsuleCollider2D>().enabled = false;      // desativa colisor do keeper
            this.enabled = false;            
        }

        if(skin.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("KeeperAttack")){
            return;
        }

        if(goRight){
            skin.localScale = new Vector3(1f,1f,1f);
            if(Vector2.Distance(transform.position, b.position) < 0.1f){
                goRight = false;    // inverte para esquerda
            }
            transform.position = Vector2.MoveTowards(transform.position, b.position, speedMove * Time.deltaTime); // vai para direita
        }else{
            skin.localScale = new Vector3(-1f,1f,1f);
            if(Vector2.Distance(transform.position, a.position) < 0.1f){
                goRight = true;    // inverte para direita
            }
            transform.position = Vector2.MoveTowards(transform.position, a.position, speedMove * Time.deltaTime); // vai para esquerda
        }
        
    }
}
