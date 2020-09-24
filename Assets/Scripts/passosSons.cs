using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passosSons : MonoBehaviour
{
    AudioSource som;
    // Start is called before the first frame update
    void Start()
    {
        som = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
     if (collision.CompareTag("Player")){
         som.Play();
     }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag("Player")){
            som.Pause();
        }
    }
    
}
