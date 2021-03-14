﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public int questID;
    private QuestManager manager;

    public string startText, completeText;

    public bool needsItem;
    public string itemNeeded;

    public bool needsEnemy;
    public string enemyName;
    
    public int numberOfEnemies;
    private int enemiesKilled;

    private CharacterStats characterStats;
    public int XPQuest;
    //se puede aplicar el contador a items;

    private void Start()
    {
        manager = FindObjectOfType<QuestManager>();
        characterStats = FindObjectOfType<CharacterStats>();
    }

    private void Update()
    {
        if(needsItem && manager.itemCollected.Equals(itemNeeded))
        {
            manager.itemCollected = null;
            CompleteQuest();
        }
        if(needsEnemy && manager.enemyKilled.Equals(enemyName))
        {
            manager.enemyKilled = null;
            enemiesKilled++;
            if (enemiesKilled >= numberOfEnemies)
            {
                CompleteQuest();
            }
        }
    }
    public void StartQuest()
    {
        manager = FindObjectOfType<QuestManager>();
        manager.ShowQuestText(startText);
    }
    public void CompleteQuest()
    {
        manager.ShowQuestText(completeText);
        manager.questCompleted[questID] = true;
        gameObject.SetActive(false);
        characterStats.AddExperience(XPQuest);
    }
}
