using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teletranportar : MonoBehaviour
{
    
    private PlayerControler player;
    private SFXManager sFXManager;

    void Start()
    {
        sFXManager = FindObjectOfType<SFXManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>();
        
    }

    // Update is called once per frame
    public void Use()
    {
        sFXManager.libroAbrir.Play();
        player.ReturnTeleport();
        Destroy(gameObject);
    }
}
