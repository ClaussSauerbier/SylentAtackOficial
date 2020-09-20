using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parede : MonoBehaviour
{
    public static bool granadaAtiva = false;

    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !Inimigo.inimigoAvistado)
        {
            Inimigo.podeAtacar = false;
            collision.transform.GetComponent<BoxCollider2D>().offset = new Vector2( 0, -0.2f);
            collision.GetComponent<InfoSCR>().MudaTexto("Escondido");
        }
        else if (collision.CompareTag("Player") && Inimigo.inimigoAvistado)
        {
            Inimigo.podeAtacar = true;
            collision.GetComponent<InfoSCR>().MudaTexto("Voce foi Visto!");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!granadaAtiva)
            {
                Inimigo.podeAtacar = true;
            }
            collision.transform.GetComponent<BoxCollider2D>().offset = new Vector2(0, 0);
            collision.GetComponent<InfoSCR>().MudaTexto("");
        }
    }
}
