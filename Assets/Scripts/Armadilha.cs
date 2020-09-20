using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armadilha : MonoBehaviour
{
    Animator animador;
    public bool lancaChamas, bateBate;
    public GameObject exp;

    // Start is called before the first frame update
    void Start()
    {
        animador = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Desativar()
    {
        if (bateBate)
        {
            animador.SetBool("Ativo", false);
            GetComponent<BoxCollider2D>().enabled = false;
        }
        if (lancaChamas)
        {
            Destroy(gameObject);
        }
        Instantiate(exp, transform.position, transform.rotation);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player.vida = 0;
            collision.transform.GetComponent<Player>().Morto();
        }
  

    }
}
