using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aquario : MonoBehaviour
{
    Animator animador;
    public GameObject itemVida, fx;
    bool podeAction = false;

    void Start()
    {
        animador = GetComponent<Animator>();
    }


    public void Action()
    {
        if (podeAction)
        { 
            animador.SetTrigger("Quebra");
            GetComponent<BoxCollider2D>().enabled = false;
            Instantiate(itemVida, transform.position, transform.rotation);
            Instantiate(fx, transform.position, transform.rotation);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<InfoSCR>().MudaTexto("Destruir");
            podeAction = true;

        }
        if (collision.CompareTag("Estrela"))
        {
            podeAction = true;
            Action();
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<InfoSCR>().MudaTexto("");
            podeAction = false;
        }
    }
}
