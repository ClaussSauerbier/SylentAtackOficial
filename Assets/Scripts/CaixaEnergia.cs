using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaixaEnergia : MonoBehaviour
{
    public GameObject explosao;
    bool podeAction = false;
    public int raio, loops;
    public LayerMask layer;

    // Start is called before the first frame update
    void Start()
    {

    }
    public void Action()
    {
        if (podeAction)
        {
            Instantiate(explosao, transform.position, transform.rotation);
            GetComponent<Animator>().SetTrigger("Explode");
            GetComponent<BoxCollider2D>().enabled = false;
            
            for(int i=0; i<loops; i++)
            {
                if (Physics2D.OverlapCircle(transform.position, raio, layer))
                {
                    Collider2D collider = Physics2D.OverlapCircle(transform.position, raio, layer);
                    if (collider.transform.GetComponent<Armadilha>())
                    {
                        collider.transform.GetComponent<Armadilha>().Desativar();
                    }
                }
                
            }
            
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
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, raio);
    }
}
