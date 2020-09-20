using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refem : MonoBehaviour
{
    public bool livre = false, podeVoar = false;
    public float velocidade;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (livre)
        {
            StartCoroutine("Voar");
        }
        if (podeVoar)
        {
            GetComponent<SpriteRenderer>().sortingOrder = 10;
            pos.y += 1 * velocidade * Time.deltaTime;
            transform.position = pos;
        }
        
    }
    IEnumerator Voar()
    {
        yield return new WaitForSeconds(1);
        podeVoar = true;
    }
}
