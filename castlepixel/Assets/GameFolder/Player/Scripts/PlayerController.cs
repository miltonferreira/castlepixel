using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;
    Vector2 vel;

    public LayerMask floorLayer;    // layer do chao do game
    public Transform floorCollider; // colisor do pé do player
    public Transform skin;

    int numeroCombo;
    public float tempoCombo;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

        tempoCombo = tempoCombo + Time.deltaTime;

        // *** countdown é o tempo para poder atacar novamente
        if(Input.GetButtonDown("Fire1") && tempoCombo > 0.5f){

            numeroCombo++;
            if(numeroCombo>2){numeroCombo = 1;} // volta para primeiro attack

            tempoCombo = 0f;
            skin.GetComponent<Animator>().Play("PlayerAttack"+numeroCombo, -1);
        }
        if(tempoCombo >= 0.6f){numeroCombo = 0;} // reseta ataque com combo

        // faz player pular
        bool canJump = Physics2D.OverlapCircle(floorCollider.position, 0.1f, floorLayer);
        if(Input.GetButtonDown("Jump") && canJump){
            skin.GetComponent<Animator>().Play("PlayerJump", -1);
            rb.velocity = Vector2.zero; // zera velocidade xy
            rb.AddForce(new Vector2(0f, 150f));
        }

        vel = new Vector2(Input.GetAxisRaw("Horizontal") * 1.5f, rb.velocity.y);

        // animação de andar
        if(Input.GetAxisRaw("Horizontal") != 0){
            skin.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1f, 1f);
            skin.GetComponent<Animator>().SetBool("PlayerRun", true);
        }else{
            skin.GetComponent<Animator>().SetBool("PlayerRun", false);
        }
    }

    // FixedUpdate ideal para fisica no Unity
    private void FixedUpdate() {
        rb.velocity = vel;
    }
}
