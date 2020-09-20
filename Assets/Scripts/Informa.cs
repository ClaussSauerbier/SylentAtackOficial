using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Informa : MonoBehaviour
{
    [Header("Digite a informação")]
    [TextArea]
    public string info = "";
    public AudioClip som;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<AudioSource>().PlayOneShot(som);
            collision.transform.GetComponent<InfoSCR>().Tutorial(info);
            Destroy(gameObject, 0.1f);
        }
    }

}
