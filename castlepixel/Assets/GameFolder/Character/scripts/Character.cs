using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{

    public int life;
    private bool isDead;
    public Transform skin;

    // text ----------------------------------------
    public Text heartCountText;
    
    // Update is called once per frame
    void Update()
    {
        if(life <=0 && !isDead){
            isDead = true;
            if(skin != null)
            skin.GetComponent<Animator>().Play("Die", -1);
        }
    }

    public void PlayerDamage(int value){
        life-=value;
        skin.GetComponent<Animator>().Play("PlayerBlink", 1);
        heartCountText.text = "x"+life.ToString();
    }

    public void addLife(int value){
        life+=value;    // add +value life
        heartCountText.text = "x"+life.ToString();
    }
}
