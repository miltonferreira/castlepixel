using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;
    Vector2 vel;

    [Header("velocidade Movimento")]
    public float speedMove;
    [Header("Altura Pulo")]
    public float jumpForce;
    [Header("Velocidade Dash")]
    public float dashForce;
    public LayerMask floorLayer;    // layer do chao do game
    public Transform floorCollider; // colisor do pé do player
    public Transform skin;

    // combos ------------------------------------------------------
    public int ComboNun;           // quantidades de combos, aqui são 1 e 2
    public float comboTime; // tempo para poder combar ataques

    // dash ------------------------------------------------------
    public float dashTime;

    public string currentLevel; // pega scene atual

    // sons do player --------------------------------------------
    [HideInInspector]
    public AudioSource audioSource;
    [Header("Sons Player")]
    public AudioClip attack1Sound, attack2Sound, groudedSound, damageSound, dashSound;
    private bool isGrounded;

    public Transform gameOverScreen;
    public Transform pauseScreen;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        audioSource = GetComponent<AudioSource>();

        currentLevel = SceneManager.GetActiveScene().name;  // pega nome da scene
        DontDestroyOnLoad(transform.gameObject);            // não destroi player
        
    }

    // Update is called once per frame
    void Update()
    {

        if(!currentLevel.Equals(SceneManager.GetActiveScene().name)){
            currentLevel = SceneManager.GetActiveScene().name;                  // pega nome da scene
            transform.position = GameObject.Find("Spawn").transform.position;   //posiciona player no spawn
        }

        // desativa este script --------------------------------------------------------------------
        if(GetComponent<Character>().life <= 0){
            gameOverScreen.GetComponent<GameOver>().enabled = true;
            this.enabled = false;
        }

        // botao de pausa do game ------------------------------------------------------------------
        if(Input.GetButtonDown("Cancel")){
            pauseScreen.GetComponent<Pause>().enabled = !pauseScreen.GetComponent<Pause>().enabled;
        }

        // animação de dash ------------------------------------------------------------------------
        dashTime = dashTime + Time.deltaTime;
        if(Input.GetButtonDown("Fire2") && dashTime > 1f){
            audioSource.PlayOneShot(dashSound, 0.5f);

            dashTime = 0f;
            skin.GetComponent<Animator>().Play("PlayerDash", -1);
            rb.velocity = Vector2.zero; // zera velocidade xy
            rb.AddForce(new Vector2(skin.localScale.x * dashForce, 0f));
        }

        // animação de ataque/combo ----------------------------------------------------------------
        comboTime = comboTime + Time.deltaTime;

        // *** countdown é o tempo para poder atacar novamente
        if(Input.GetButtonDown("Fire1") && comboTime > 0.5f){

            ComboNun++;
            if(ComboNun>2){ComboNun = 1;} // volta para primeiro attack

            comboTime = 0f;
            skin.GetComponent<Animator>().Play("PlayerAttack"+ComboNun, -1);

            if(ComboNun == 1){
                audioSource.PlayOneShot(attack1Sound, 0.5f);
            }else{
                audioSource.PlayOneShot(attack2Sound, 0.5f);
            }
        }
        if(comboTime >= 0.6f){ComboNun = 0;} // reseta ataque com combo

        // animação de pular ---------------------------------------------------------------------
        bool canJump = Physics2D.OverlapCircle(floorCollider.position, 0.1f, floorLayer);

        if(canJump && !isGrounded){
            isGrounded = true;
            audioSource.PlayOneShot(groudedSound, 0.5f);
        }else if(!canJump){
            isGrounded = false;
        }

        if(Input.GetButtonDown("Jump") && canJump){
            skin.GetComponent<Animator>().Play("PlayerJump", -1);
            rb.velocity = Vector2.zero; // zera velocidade xy
            rb.AddForce(new Vector2(0f, jumpForce));
        }

        // animação de andar ------------------------------------------------------------------------
        vel = new Vector2(Input.GetAxisRaw("Horizontal") * speedMove, rb.velocity.y);

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

    public void DestroyPlayer(){
        Destroy(transform.gameObject);
    }
}
