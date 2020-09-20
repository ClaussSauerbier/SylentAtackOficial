using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Vector3 posCheck;
    public static Vector3 posStaticCamera;
    public GameObject fx;
    
    public Text vidaTxt, estrelaText, granadaText, vidasText;
    
    public float velocidade = 5, forcaPulo = 6 , raioPulo, raioSurdina, raioAction;
    private float andar;
    private bool pulando, abaixado, podeAtirar = true, podeMover = true, morto = false, podeSurdina = false;
    private Vector3 pos;
    private Rigidbody2D rb;

    public Animator animador;

    public static float vida = 100, estrelaAmmo, granadaAmmo, vidasTotal = 2;
    public static bool mortoParaInimigo = false, botaoAcao = false;
    public static bool estaComChave = false, estaComCartao = false;
    
    public LayerMask plataformaLayer, inimigoLayer, actionLayer;
    public GameObject estrela, granada, sangue;
    public Transform estrelaPOS;

    void Start()
    {
        MenuSCR.pauseStatic = false;
        Time.timeScale = 1;
        morto = false;
        mortoParaInimigo = false;
        rb = GetComponent<Rigidbody2D>();
        animador = GetComponent<Animator>();
        estrelaText.text = "" + estrelaAmmo;
        granadaText.text = "" + granadaAmmo;
        vidasText.text = "" + vidasTotal;
        vidaTxt.text = "" + vida;
        estaComCartao = false;
        estaComChave = false;
        posCheck = transform.position;
        transform.position = posCheck;
    }
    private void Update()
    {
        if (!MenuSCR.pauseStatic)
        {
            ControlesKeyUpdate();
            AnimacaoUpdate();
            CameraMove();
        }
        
    }
    void CameraMove()
    {
        posStaticCamera = transform.position;
    }
    public void Morto()
    {
        vidaTxt.text = "" + vida;
        Instantiate(sangue, transform.position, transform.rotation);
        if (vida <= 0)
        {
            podeMover = false;
            morto = true;
            mortoParaInimigo = true;
            vidasTotal -= 1;
            StartCoroutine("MortoCor");
        } 
    }
    IEnumerator MortoCor()
    {
        yield return new WaitForSeconds(3);
        if (vidasTotal < 0)
        {
            vida = 100;
            vidasTotal = 2;
            estrelaAmmo = 0;
            granadaAmmo = 0;
            SceneManager.LoadScene("Fases");
        }
        else
        {
            morto = false;
            vida = 100;
            estrelaAmmo = 0;
            granadaAmmo = 0;
            transform.position = posCheck;
            vidasText.text = "" + vidasTotal;
            podeMover = true;
            mortoParaInimigo = false;
            estrelaText.text = "" + estrelaAmmo;
            granadaText.text = "" + granadaAmmo;
            vidasText.text = "" + vidasTotal;
            estaComCartao = false;
            estaComChave = false;
            Instantiate(fx, transform.position, transform.rotation);
        }
        
    }
    //Movimento dos botoes//////////////////////////////
    public void MoverEsquerda()
    {
        andar = -1;
    }
    public void MoverDireita()
    {
        andar = 1;
    }
    public void Neutro()
    {
        andar = 0;
    }
    /// /////////////////////////////////////////////////
    void ControlesKeyUpdate()
    {
        pos = transform.position;
        if (podeMover)
        {
            if (!abaixado)
            {
                pos.x += Input.GetAxis("Horizontal") * velocidade * Time.deltaTime;
                pos.x += andar * velocidade * Time.deltaTime;
                transform.position = pos;
            }
            
            
            if (Input.GetKeyDown("s") )
            {
                Abaixar();
            }
            if (Input.GetKeyUp("s"))
            {
                Levantar();
            }
            if (Input.GetKeyDown("w"))
            {
                Jump();  
            }
            
            if (Input.GetKeyDown("e"))
            {
                LaunchStar();
            }
            if (Input.GetKeyDown("g"))
            {
                LaunchGranada();
            }
            if (Input.GetKeyDown("f"))
            {
                Acao();
            }
        }     
    }
    public void Abaixar()
    {
        abaixado = true;
        animador.SetBool("Crouch", true);
    }
    public void Levantar()
    {
        abaixado = false;
        animador.SetBool("Crouch", false);
    }
    public void LaunchStar()
    {
        if(estrelaAmmo > 0)
        {
            
            StartCoroutine("FireEstrela");
            
        }
        
    }
    public void LaunchGranada()
    {
        if(granadaAmmo > 0)
        {
            
            StartCoroutine("Granada");
            
        }
    }
    public void Jump()
    {
        if (Physics2D.Raycast(transform.position, -transform.up, raioPulo, plataformaLayer ) && !morto)
        {
            rb.AddForce(new Vector2(0, forcaPulo) , ForceMode2D.Impulse); 
        } 
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Inimigo"))
        {
            GetComponent<InfoSCR>().MudaTexto("Atack");
            podeSurdina = true;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Inimigo"))
        {
            GetComponent<InfoSCR>().MudaTexto("");
            podeSurdina = false;
        }
    }

    IEnumerator MoveAposSegundos()
    {
        yield return new WaitForSeconds(0.5f);
        podeMover = true;
    }
    IEnumerator FireEstrela()
    {
        if (podeAtirar)
        { 
            animador.SetTrigger("Launch");
            podeAtirar = false;
            yield return new WaitForSeconds(0.3f);
            estrelaAmmo -= 1;
            estrelaText.text = "" + estrelaAmmo;
            Instantiate(estrela, estrelaPOS.position, estrelaPOS.rotation);
        }
        yield return new WaitForSeconds(1f);
        podeAtirar = true;
    }
    IEnumerator Granada()
    {
        if(podeAtirar)
        {
            animador.SetTrigger("Launch");
            podeAtirar = false;
            yield return new WaitForSeconds(0.3f);
            granadaAmmo -= 1;
            granadaText.text = "" + granadaAmmo;
            Instantiate(granada, estrelaPOS.position, estrelaPOS.rotation);
        }
        yield return new WaitForSeconds(1f);
        podeAtirar = true;
    }

    void AnimacaoUpdate()
    {
        if (!morto)
        {
            animador.SetBool("Dead", false);
            if (Input.GetAxis("Horizontal") > 0 && !pulando || andar > 0)
            {
                animador.SetBool("Run", true);
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if (Input.GetAxis("Horizontal") < 0 && !pulando || andar < 0)
            {
                animador.SetBool("Run", true);
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else
            {
                animador.SetBool("Run", false);
            }

            if (!Physics2D.Raycast(transform.position, -transform.up, raioPulo, plataformaLayer))
            {
                animador.SetBool("Jump", true);
                pulando = true;
            }
            else
            {
                animador.SetBool("Jump", false);
                pulando = false;
            }
        }
        else
        {
            animador.SetBool("Run", false);
            animador.SetBool("Crouch", false);
            animador.SetBool("Jump", false);
            animador.SetBool("Dead", true);
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawLine(transform.position, transform.position-(transform.up * raioPulo), Color.red);
        Debug.DrawLine(transform.position, transform.position + (transform.right * raioSurdina), Color.blue);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, raioAction);
    }

    public void Acao()
    {
        //Itens:
        Collider2D collider = Physics2D.OverlapCircle(transform.position, raioAction, actionLayer);
        if (collider != null)
        {
            if (collider.GetComponent<PortaElev>())
            {
                collider.GetComponent<PortaElev>().NewLevel();
            }
            if (collider.GetComponent<CaixaEnergia>())
            {
                collider.GetComponent<CaixaEnergia>().Action();
            }
            if (collider.GetComponent<Aquario>())
            {
                collider.GetComponent<Aquario>().Action();
            }
        }

        //Surdina:
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, raioSurdina, inimigoLayer);
        if (hit.collider != null && podeSurdina)
        {
            podeSurdina = false;
            podeMover = false;
            StartCoroutine("MoveAposSegundos");
            animador.SetTrigger("Launch");
            animador.SetBool("Run", false);
            animador.SetBool("Crouch", false);
            animador.SetBool("Jump", false);
            hit.transform.GetComponent<Inimigo>().Morte();
        }
    }
}
