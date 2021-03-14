using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int value;
    private CoinManager manager;
    void Start()
    {
        manager = FindObjectOfType<CoinManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            manager.AddMoney(value);
            Destroy(gameObject);
        }
    }
}
