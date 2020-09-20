using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    //public static Vector3 checkPointPos;
    public GameObject fx;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player.posCheck = collision.transform.position;
            Instantiate(fx, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
