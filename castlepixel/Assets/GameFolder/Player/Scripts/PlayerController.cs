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

    // combos ------------------------------------------------------
    public int ComboNun;           // quantidades de combos, aqui são 1 e 2
    public float comboTime; // tempo para poder combar ataques

    // dash ------------------------------------------------------
    public float dashTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

        // desativa este script --------------------------------------------------------------------
        if(GetComponent<Character>().life <= 0){this.enabled = false;}

        // animação de dash ------------------------------------------------------------------------
        dashTime = dashTime + Time.deltaTime;
        if(Input.GetButtonDown("Fire2") && dashTime > 1f){
            dashTime = 0f;
            skin.GetComponent<Animator>().Play("PlayerDash", -1);
            rb.velocity = Vector2.zero; // zera velocidade xy
            rb.AddForce(new Vector2(skin.localScale.x * 150f, 0f));
        }

        // animação de ataque/combo ----------------------------------------------------------------
        comboTime = comboTime + Time.deltaTime;

        // *** countdown é o tempo para poder atacar novamente
        if(Input.GetButtonDown("Fire1") && comboTime > 0.5f){

            ComboNun++;
            if(ComboNun>2){ComboNun = 1;} // volta para primeiro attack

            comboTime = 0f;
            skin.GetComponent<Animator>().Play("PlayerAttack"+ComboNun, -1);
        }
        if(comboTime >= 0.6f){ComboNun = 0;} // reseta ataque com combo

        // animação de pular ---------------------------------------------------------------------
        bool canJump = Physics2D.OverlapCircle(floorCollider.position, 0.1f, floorLayer);
        if(Input.GetButtonDown("Jump") && canJump){
            skin.GetComponent<Animator>().Play("PlayerJump", -1);
            rb.velocity = Vector2.zero; // zera velocidade xy
            rb.AddForce(new Vector2(0f, 150f));
        }

        // animação de andar ------------------------------------------------------------------------
        vel = new Vector2(Input.GetAxisRaw("Horizontal") * 1.5f, rb.velocity.y);

        if(Input.GetAxisRaw("Horizontal") != 0){
            skin.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1f, 1f);
            skin.GetComponent<Animator>().SetBool("PlayerRun", true);
        }else{
            skin.GetComponent<Animator>().SetBool("PlayerRun", false);
        }
    }

    // FixedUpdate ideal para fisica no Unity
    private void FixedUpdate() {
        if(dashTime > 0.5f){
            rb.velocity = vel;
        }
    }
}
