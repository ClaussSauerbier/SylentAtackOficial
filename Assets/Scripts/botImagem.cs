using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class botImagem : MonoBehaviour
{
    Image rend;
    public Sprite img;
    public int fase;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Image>();
        if(MenuSCR.fase1_Open & fase == 1){
            rend.sprite = img;
        }
        if(MenuSCR.fase2_Open & fase == 2){
            rend.sprite = img;
        }
        if(MenuSCR.fase3_Open & fase == 3){
            rend.sprite = img;
        }
        if(MenuSCR.fase4_Open & fase == 4){
            rend.sprite = img;
        }
        if(MenuSCR.fase5_Open & fase == 5){
            rend.sprite = img;
        }
        if(MenuSCR.fase6_Open & fase == 6){
            rend.sprite = img;
        }
        if(MenuSCR.fase7_Open & fase == 7){
            rend.sprite = img;
        }
    }
}
