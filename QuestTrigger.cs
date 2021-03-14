using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class QuestTrigger : MonoBehaviour
{
    private QuestManager manager;
    public int questId;
    public bool startPoint, endPoint;


    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<QuestManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if (!manager.questCompleted[questId])
            {
                if(startPoint && !manager.quest[questId].gameObject.activeInHierarchy)
                {
                    manager.quest[questId].gameObject.SetActive(true);
                    manager.quest[questId].StartQuest();
                }
                if(endPoint && manager.quest[questId].gameObject.activeInHierarchy)
                {
                    manager.quest[questId].CompleteQuest();
                }
            }
        }
    }
}
