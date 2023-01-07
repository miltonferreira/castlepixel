using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public int life;
    private bool isDead;
    public Transform skin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(life <=0 && !isDead){
            isDead = true;
            if(skin != null)
            skin.GetComponent<Animator>().Play("Die", -1);
        }
    }
}
