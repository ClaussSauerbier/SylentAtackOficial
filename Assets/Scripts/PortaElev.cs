using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PortaElev : MonoBehaviour
{
    public int raio;
    public bool usarChave, usarCard;
    bool podeAction = false;
    public LayerMask layer;

    [Header("Digite level de (0 a 7)")]
    public string level;
    Animator animador;

    // Start is called before the first frame update
    void Start()
    {
        animador = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        { 
            if (usarCard)
            {
                if (Player.estaComCartao)
                {
                    GetComponent<AudioSource>().Play();
                    podeAction = true;
                    collision.GetComponent<InfoSCR>().MudaTexto("Entrar");
                    animador.SetBool("PortaAbre", true);
                }
                else
                {
                    collision.GetComponent<InfoSCR>().MudaTexto("Sem Cartao");
                }
            }

            if(usarChave)
            {
                if (Player.estaComChave)
                {
                    podeAction = true;
                    collision.GetComponent<InfoSCR>().MudaTexto("Abrir");  
                    
                } 
                else
                {
                    collision.GetComponent<InfoSCR>().MudaTexto("Trancado");
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<InfoSCR>().MudaTexto(""); 
            podeAction = false;
            if (usarCard)
            {
                animador.SetBool("PortaAbre", false);
                if(Player.estaComCartao){
                    GetComponent<AudioSource>().Play();
                }
            }
        }
    }
    public void NewLevel()
    {
        if (podeAction && usarCard && Player.estaComCartao)
        {
            SceneManager.LoadScene("Fase" + level);
        }
        if(podeAction && usarChave && Player.estaComChave)
        {
            animador.SetBool("PortaAbre", true);
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<AudioSource>().Play();

            Collider2D collider = Physics2D.OverlapCircle(transform.position, raio, layer);
            if (collider.transform.GetComponent<Refem>())
            {
                collider.transform.GetComponent<Refem>().livre = true;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, raio);
    }
}
