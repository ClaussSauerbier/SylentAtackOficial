using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itens : MonoBehaviour
{
    public bool cartao, chave, ammo, granada, vida, vidasTotal;
    public int numeroMunicao;
    public GameObject fx;


    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !Player.mortoParaInimigo)
        {
            if (cartao)
            {
                Player.itemSTC = true;
                Player.estaComCartao = true;
                Instantiate(fx, transform.position, transform.rotation);
                Destroy(gameObject); 
            }
            if (chave)
            {
                Player.itemSTC = true;
                Player.estaComChave = true;
                Instantiate(fx, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            if (ammo)
            {
                Player.itemSTC = true;
                Player.estrelaAmmo += numeroMunicao;
                collision.transform.GetComponent<Player>().estrelaText.text = "" + Player.estrelaAmmo;
                Instantiate(fx, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            if (granada)
            {
                Player.itemSTC = true;
                Player.granadaAmmo += numeroMunicao;
                collision.transform.GetComponent<Player>().granadaText.text = "" + Player.granadaAmmo;
                Instantiate(fx, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            if (vidasTotal)
            {
                Player.vidaSTC = true;
                Player.vidasTotal += numeroMunicao;
                collision.transform.GetComponent<Player>().vidasText.text = "" + Player.vidasTotal;
                Instantiate(fx, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            if (vida)
            {
                if (Player.vida < 100)
                {
                    Player.saudeSTC = true;
                    Player.vida += numeroMunicao;
                    if (Player.vida > 100)
                    {
                        Player.vida = 100;
                    }
                    collision.transform.GetComponent<Player>().vidaTxt.text = "" + Player.vida;
                    Instantiate(fx, transform.position, transform.rotation);
                    Destroy(gameObject);
                }
                
            }
        }
    }
}
