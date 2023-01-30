using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerLevel : MonoBehaviour
{

    public string levelName;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            SceneManager.LoadScene(levelName);
        }
    }
}
