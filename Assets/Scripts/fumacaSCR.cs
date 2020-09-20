using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fumacaSCR : MonoBehaviour
{
    bool ativado = true;

    void Start()
    {
        StartCoroutine("gra");
        Destroy(gameObject, 20);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && ativado)
        {
            Inimigo.podeAtacar = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Inimigo.podeAtacar = true;
        }
    }
    IEnumerator gra()
    {
        Parede.granadaAtiva = true;
        yield return new WaitForSeconds(6);
        Parede.granadaAtiva = false;
        ativado = false;
        Inimigo.podeAtacar = true;
    }
}
