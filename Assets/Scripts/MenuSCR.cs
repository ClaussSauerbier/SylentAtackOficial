using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSCR : MonoBehaviour
{
    [Header("MENU Pause")]
    public bool game;
    private bool isPause;
    public static bool pauseStatic, fase1_Open, fase2_Open, fase3_Open, fase4_Open, fase5_Open, fase6_Open, fase7_Open;
    public GameObject painel;


    // Start is called before the first frame update
    void Start()
    {
        if (game)
        {
            painel.SetActive(false);
            Time.timeScale = 1;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseGame()
    {
        if (!isPause)
        {
            painel.SetActive(true);
            isPause = true;
            pauseStatic = true;
            Time.timeScale = 0;
        }
        else
        {
            painel.SetActive(false);
            isPause = false;
            pauseStatic = false;
            Time.timeScale = 1;
        }
        
    }
    public void Sair()
    {
        Application.Quit();
    }

    public void FaseMenu()
    {

        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
    public void Fases()
    {
        Time.timeScale = 1;
        Player.vida = 100;
        Player.vidasTotal = 2;
        Player.estrelaAmmo = 0;
        Player.granadaAmmo = 0;
        SceneManager.LoadScene("Fases");
    }
    public void Fase0()
    {
        SceneManager.LoadScene("Fase0");
    }
    public void Fase1()
    {
        if(fase1_Open){
        SceneManager.LoadScene("Fase1");
        }
        
    }
    public void Fase2()
    {
        if(fase2_Open){
            SceneManager.LoadScene("Fase2");
        }
        
    }
    public void Fase3()
    {
        if(fase3_Open){
            SceneManager.LoadScene("Fase3");
        }
        
    }
    public void Fase4()
    {
        if(fase4_Open){
            SceneManager.LoadScene("Fase4");
        }
        
    }
    public void Fase5()
    {
        if(fase5_Open){
            SceneManager.LoadScene("Fase5");
        }
        
    }
    public void Fase6()
    {
        if(fase6_Open){
            SceneManager.LoadScene("Fase6");
        }
        
    }
    public void Fase7()
    {
        if(fase7_Open){
            SceneManager.LoadScene("Fase7");
        }
        
    }
    public void Fase8()
    {
        SceneManager.LoadScene("Fase8");
    }
}
