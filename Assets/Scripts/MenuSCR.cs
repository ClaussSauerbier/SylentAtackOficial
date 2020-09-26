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
    AudioSource som;
    public AudioClip clickSom;


    // Start is called before the first frame update
    void Start()
    {
        if (game)
        {
            painel.SetActive(false);
            Time.timeScale = 1;
        }
        som = GetComponent<AudioSource>();
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
        }   else{
                som.PlayOneShot(clickSom);
        }   
    }
    public void Fase2()
    {
        if(fase2_Open){
            SceneManager.LoadScene("Fase2");
        }   else{
                som.PlayOneShot(clickSom);
        }   
    }
    public void Fase3()
    {
        if(fase3_Open){
            SceneManager.LoadScene("Fase3");
        }   else{
                som.PlayOneShot(clickSom);
        }   
    }
    public void Fase4()
    {
        if(fase4_Open){
            SceneManager.LoadScene("Fase4");
        }   else{
            som.PlayOneShot(clickSom);
        }   
    }
    public void Fase5()
    {
        if(fase5_Open){
            SceneManager.LoadScene("Fase5");
        }  
        else{
                som.PlayOneShot(clickSom);
        }   
    }
    public void Fase6()
    {
        if(fase6_Open){
            SceneManager.LoadScene("Fase6");
        }
        else{
                som.PlayOneShot(clickSom);
        }   
    }
    public void Fase7()
    { 
        if(fase7_Open){
            SceneManager.LoadScene("Fase7");
        }
        else{
            som.PlayOneShot(clickSom);
        }   
        
    }
    public void Fase8()
    {
        SceneManager.LoadScene("Fase8");
    }
    void GetFases(){
        if(PlayerPrefs.GetInt("Save1") == 1){
            fase1_Open = true;
        }
        if(PlayerPrefs.GetInt("Save2") == 2){
            fase2_Open = true;
        }
        if(PlayerPrefs.GetInt("Save3") == 3){
            fase3_Open = true;
        }
        if(PlayerPrefs.GetInt("Save4") == 4){
            fase4_Open = true;
        }
        if(PlayerPrefs.GetInt("Save5") == 5){
            fase5_Open = true;
        }
        if(PlayerPrefs.GetInt("Save6") == 6){
            fase6_Open = true;
        }
        if(PlayerPrefs.GetInt("Save7") == 7){
            fase7_Open = true;
        }
    }

    public void NewGame(){
        PlayerPrefs.SetInt("Save1", 0);
        PlayerPrefs.SetInt("Save2", 0);
        PlayerPrefs.SetInt("Save3", 0);
        PlayerPrefs.SetInt("Save4", 0);
        PlayerPrefs.SetInt("Save5", 0);
        PlayerPrefs.SetInt("Save6", 0);
        PlayerPrefs.SetInt("Save7", 0);
        fase1_Open = false;
        fase2_Open = false;
        fase3_Open = false;
        fase4_Open = false;
        fase5_Open = false;
        fase6_Open = false;
        fase7_Open = false;
        LoadGame();
    }

    public void LoadGame(){
        GetFases();
        SceneManager.LoadScene("Fases");
    }
    public void SaveLoad(){
        SceneManager.LoadScene("SaveLoad");
    }
}
