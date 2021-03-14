using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class QuestItems : MonoBehaviour
{
    public int questId;
    private QuestManager manager;
    public string itemName;

    
    private void Start()
    {
        manager = FindObjectOfType<QuestManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if(manager.quest[questId].gameObject.activeInHierarchy &&
                !manager.questCompleted[questId])
            {
                manager.itemCollected = itemName;
                gameObject.SetActive(false);
            }
        }
    }
}
