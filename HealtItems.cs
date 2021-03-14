using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class HealtItems : MonoBehaviour
{
    private HealtManager healtManager;
    public int restaurar;
    private SFXManager sFXManager;

    private void Start()
    {
        sFXManager = FindObjectOfType<SFXManager>();
        healtManager = GameObject.FindGameObjectWithTag("Player").GetComponent<HealtManager>();
    }

    public void Use()
    {
        // Instantiate(healthEffect, player.transform.position, Quaternion.identity);
        
        
        if (healtManager.currentHealth <= healtManager.maxHealth)
        {
            sFXManager.botella.Play();
            healtManager.currentHealth += restaurar;
            
            if(healtManager.currentHealth >= healtManager.maxHealth)
            {
                healtManager.currentHealth = healtManager.maxHealth;
            }
        }
      
        
        Destroy(gameObject);
    }
}


