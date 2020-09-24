using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    AudioSource som;
    public AudioClip grito, arma;
    public bool robo;
    public GameObject fumacaFX;
    Animator animador;
    private bool morto = false, fire;
    public int dano;
    public LayerMask playerLayer;
    public float raio, raio2, velocidade;
    public GameObject explosao;

    public static bool podeAtacar = true, inimigoAvistado = false;
    int mov = 1;

    Vector3 pos;

    void Start()
    {
        podeAtacar = true;
        inimigoAvistado = false;
        pos = transform.position;
        animador = GetComponent<Animator>();
        som = GetComponent<AudioSource>();
        fire = true;
    }


    void Update()
    {
        if (!MenuSCR.pauseStatic)
        {
            if (colidindo())
            {
                Parar();

            }
            if (playerNoRaioDeVisao() && podeAtacar && !Player.mortoParaInimigo && !morto)
            {
                Atacar();
                inimigoAvistado = true;

            }
            else
            {
                Patrulhar();

            }
        }
       
    }
    public void Morte()
    {
        StartCoroutine("Morrer");
    }
    IEnumerator Morrer()
    {
        if (robo)
        {
            Instantiate(fumacaFX, transform.position, transform.rotation);
        }
        som.PlayOneShot(grito, 1f);
        morto = true;
        animador.SetBool("Fire", false);
        animador.SetBool("Run", false);
        animador.SetBool("Dead", true);
        GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(4);
        Instantiate(explosao, transform.position, transform.rotation);
        fire = true;
        Destroy(gameObject);
    }
    void Atacar()
    {
        if(fire){
            fire = false;
            StartCoroutine("Atack");
        }
        
    }
    IEnumerator Atack(){
        som.PlayOneShot(arma);
        animador.SetBool("Fire", true);
        animador.SetBool("Run", false);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.right, raio, playerLayer);
        if (hit.transform.GetComponent<Player>())
        {
            Player.vida -= 1 * dano;
            if(Player.vida < 0){
                 Player.vida = 0;
                }
            hit.transform.GetComponent<Player>().Morto();
        }
        
        yield return new WaitForSeconds(0.1f);
        fire = true;
    }
    void Parar()
    {
        if(mov == 1)
        {
            StartCoroutine(Virar(1));
        }
        if(mov == 2)
        {
            StartCoroutine(Virar(2));
        }
        mov = 0;
        animador.SetBool("Fire", false);
        animador.SetBool("Run", false);
    }
    IEnumerator Virar(int num)
    {
        yield return new WaitForSeconds(2);
        if(num == 1 && !morto)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            mov = 2;
            inimigoAvistado = false;
        }
        if (num == 2 && !morto)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            mov = 1;
            inimigoAvistado = false;
        }
    }
    void Patrulhar()
    {
        if(mov == 1 && !morto)
        {
            pos.x -= 1 * velocidade * Time.deltaTime;
            animador.SetBool("Run", true);
            animador.SetBool("Fire", false);
        }
        if(mov == 2 && !morto)
        {
            pos.x += 1 * velocidade * Time.deltaTime;
            animador.SetBool("Run", true);
            animador.SetBool("Fire", false);
        }
        transform.position = pos;
    }
    bool playerNoRaioDeVisao()
    {
        if(Physics2D.Raycast(transform.position, -transform.right, raio, playerLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    bool colidindo()
    {
        if(Physics2D.OverlapCircle(transform.position - transform.right * 0.5f, raio2))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Estrela"))
        {
            StartCoroutine("Morrer");
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawLine(transform.position, transform.position-(transform.right * raio), Color.red);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position - transform.right*0.5f, raio2);
    }
}
