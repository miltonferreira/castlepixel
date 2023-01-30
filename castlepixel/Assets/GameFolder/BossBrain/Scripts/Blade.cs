using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{

    public Transform A,B,C,D;

    public Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = A.position;
    }

    // Update is called once per frame
    void Update(){
        if(transform.position == A.position){
            targetPosition = B.position;
        }else if(transform.position == B.position){
            targetPosition = C.position;
        }else if(transform.position == C.position){
            targetPosition = D.position;
        }else if(transform.position == D.position){
            targetPosition = A.position;
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, 5 * Time.deltaTime);

        transform.Rotate(0f,0f, -500 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            other.GetComponent<Character>().PlayerDamage(1);
        }
    }

}
