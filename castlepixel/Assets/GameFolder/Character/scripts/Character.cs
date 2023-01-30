using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{

    public int life;
    private bool isDead;
    public Transform skin;

    // text ----------------------------------------
    public Text heartCountText;

    public Transform cam;
    public AudioClip bossBattleMusic, youWin;
    
    // Update is called once per frame
    void Update()
    {
        if(life <=0 && !isDead && !transform.name.Equals("BossBrain")){
            isDead = true;
            if(skin != null)
            skin.GetComponent<Animator>().Play("Die", -1);
        }

        CodePlayer();

        CodeBoss();
        
    }

    void CodePlayer(){
        if(transform.CompareTag("Player")){
            if(SceneManager.GetActiveScene().name.Equals("LevelBoss")){
                CamSettings();
            }
        }
    }

    void CamSettings(){
        //cam.GetComponent<Animator>().enabled = false;   // não tem animação de balançar camera
        //cam.GetComponent<Camera>().orthographicSize = 10.3f;
        //cam.position = new Vector3(0, 4.06f,-1);
        //cam.parent = null;
        //SceneManager.MoveGameObjectToScene(cam.gameObject, SceneManager.GetActiveScene()); // tira do obj que não destroi quando troca de cena

        if(GameObject.Find("BossBrain").GetComponent<Character>().life > 0){
            
            if(cam.GetComponent<AudioSource>().clip != bossBattleMusic){
                cam.GetComponent<AudioSource>().clip = bossBattleMusic;
                cam.GetComponent<AudioSource>().volume = 0.1f;
                cam.GetComponent<AudioSource>().Play();
            }
            
        }else{

            GameObject.Find("YouWin").GetComponent<GameOver>().enabled = true;
                
            GetComponent<PlayerController>().enabled = false;
            GetComponent<CapsuleCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

            if(cam.GetComponent<AudioSource>().clip != null){
                cam.GetComponent<AudioSource>().Stop();
                cam.GetComponent<AudioSource>().clip = null;
                cam.GetComponent<AudioSource>().PlayOneShot(youWin);
            }

        }
        
    }

    void CodeBoss(){
        if(transform.name.Equals("BossBrain")){
            // regra de 3 na vida
            transform.GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(4.45f, (life * 2.725f / 30f));

            if(life <= 0){
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;                 // cai o corpo do boss
            }

        }
    }

    public void PlayerDamage(int value){
        life-=value;
        skin.GetComponent<Animator>().Play("PlayerBlink", 1);
        heartCountText.text = "x"+life.ToString();
        GetComponent<PlayerController>().audioSource.PlayOneShot(GetComponent<PlayerController>().damageSound, 0.5f);
    }

    public void addLife(int value){
        life+=value;    // add +value life
        heartCountText.text = "x"+life.ToString();
    }
}
