using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estrela : MonoBehaviour
{
    public float velocidade;
    Rigidbody2D rb;
    public GameObject sangue;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * velocidade;
        Destroy(gameObject, 4);    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Nulo"))
        {
            if (collision.CompareTag("Inimigo"))
            {
                Instantiate(sangue, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}
