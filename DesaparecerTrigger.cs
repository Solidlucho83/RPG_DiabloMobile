using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesaparecerTrigger : MonoBehaviour
{
    private SpriteRenderer objeto;


    void Start()
    {
        objeto = gameObject.GetComponent<SpriteRenderer>();
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            objeto.color = new Color(1, 1, 1, 0);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            objeto.color = new Color(255, 255, 255, 255);
           
        }
    }
}
