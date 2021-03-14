using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Puertas : MonoBehaviour
{
    private SpriteRenderer puertaRenderer;
    private SFXManager sFXManager;

    void Start()
    {
        sFXManager = FindObjectOfType<SFXManager>();
        puertaRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sFXManager.puertaAbierta.Play();
            puertaRenderer.color = new Color(1, 1, 1, 0);
            //sFXManager.puertaCerrada.Play();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
          
            puertaRenderer.color = new Color(255, 255, 255, 255);
           
        }
    }



   

}
