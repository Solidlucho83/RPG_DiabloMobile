using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float speed;
    public int damage;
    private bool stopDealDamage;
    private bool atacando;
    private HealtManager HealtManager;

    private void Start()
    {

        HealtManager = GameObject.FindGameObjectWithTag("Player").GetComponent<HealtManager>();
     
    }

    void Update()
    {

        if (atacando == true)
        {
            if (stopDealDamage == false)
            {
                stopDealDamage = true;
                StartCoroutine(Damage());
            }
        }
    }

        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            atacando = true;        
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            atacando = false;           
        }

    }

    IEnumerator Damage()
    {
        yield return new WaitForSeconds(1f);
        HealtManager.currentHealth -= (Random.Range((damage/2), damage)/HealtManager.defense);
        stopDealDamage = false;
    }
}
