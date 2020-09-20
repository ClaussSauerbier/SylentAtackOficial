using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granada : MonoBehaviour
{
    public GameObject fumaca;
    bool podeExplodir = true;
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Nulo") && !collision.tag.Equals("Player") && podeExplodir )
        {
            StartCoroutine("GranadaAti");
        }
    }
    IEnumerator GranadaAti()
    {
        Instantiate(fumaca, transform.position, transform.rotation);
        podeExplodir = false;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
