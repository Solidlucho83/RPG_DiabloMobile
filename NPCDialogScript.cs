using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogScript : MonoBehaviour
{
    public string[] dialog;
    private DialogoManager manager;
    private bool playerInTheZone;

    private const float DoubleClick = .2f;
    private float lastclickTime;

    void Start()
    {
        manager = FindObjectOfType<DialogoManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            playerInTheZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            playerInTheZone = false;
        }
    }


    void Update()
    {
        if (playerInTheZone && Input.GetMouseButtonDown(0))
        {
            float timeSinceLastClick = Time.time - lastclickTime;
            if (timeSinceLastClick <= DoubleClick)
            {
                manager.ShowDialog(dialog);
             }
            lastclickTime = Time.time;
        }
            
    }
    
}

