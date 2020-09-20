using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InfoSCR : MonoBehaviour
{
    public Text boxTexto;
    public static string texto;

    
    [Header("Tutorial Setings")]
    public GameObject tutorial;
    public Text textoTutorial;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    public void MudaTexto(string str)
    {
        boxTexto.text = str;
    }


   
    public void Continua()
    {
        tutorial.SetActive(false);
        Time.timeScale = 1;
        MenuSCR.pauseStatic = false;
    }
    public void Tutorial(string info)
    {
        tutorial.SetActive(true);
        textoTutorial.text = info;
        Time.timeScale = 0;
        MenuSCR.pauseStatic = true;
    }

}
