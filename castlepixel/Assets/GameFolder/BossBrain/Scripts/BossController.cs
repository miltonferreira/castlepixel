using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

    public Transform A,B;
    public Vector3 targetPosition;

    public Transform laser;
    public float laserTime;

    public AudioClip bossLaugh, bossLaser;

    // Start is called before the first frame update
    void Start(){
        targetPosition = A.position;
        BossLaugh();
    }

    // Update is called once per frame
    void Update(){

        if(GetComponent<Character>().life <=0){
            return;
        }

        laserTime += Time.deltaTime;

        if(laserTime > 6f){
            laserTime = 0f;
            laser.gameObject.SetActive(false);
            laser.GetChild(0).GetComponent<TrailRenderer>().Clear();
            laser.position = transform.position;
            laser.gameObject.SetActive(true);

            GetComponent<AudioSource>().PlayOneShot(bossLaser, 0.5f);
        }

        if(transform.position == A.position){
            targetPosition = B.position;
        }else if(transform.position == B.position){
            targetPosition = A.position;
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, 5 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            other.GetComponent<Character>().PlayerDamage(1);
        }
    }

    private void BossLaugh(){
        Invoke("BossLaugh", 15);
        GetComponent<AudioSource>().PlayOneShot(bossLaugh);
    }

}
