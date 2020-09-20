using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Vector3 posPlayer, posInicial;

    public float distanciaX, distanciaY, velocidadeX, velocidadeY;
    public bool Delay = false;

    void Start()
    {
        posInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        posPlayer = Player.posStaticCamera;
        
        if (Delay)
        {
            if (posPlayer.x > posInicial.x + distanciaX)
            {
                posInicial.x += 1 * velocidadeX * Time.deltaTime;
                transform.position = posInicial;
            }
            if (posPlayer.x < posInicial.x - distanciaX)
            {
                posInicial.x -= 1 * velocidadeX * Time.deltaTime;
                transform.position = posInicial;
            }
            if (posPlayer.y > posInicial.y + distanciaY)
            {
                // posInicial.y += 1 * velocidadeY * Time.deltaTime;
                posInicial.y = Player.posStaticCamera.y;
                transform.position = posInicial;
            }
            if (posPlayer.y < posInicial.y - distanciaY)
            {
                //posInicial.y -= 1 * velocidadeY * Time.deltaTime;
                posInicial.y = Player.posStaticCamera.y;
                transform.position = posInicial;
            }
        }
        else
        {
            posPlayer.z = -10;
            transform.position = posPlayer;
        }


    }
}
