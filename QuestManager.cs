using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public Quest[] quest;
    public bool[] questCompleted;

    private DialogoManager manager;
    public string itemCollected;
    public string enemyKilled;

    private void Start()
    {
        questCompleted = new bool[quest.Length];
        manager = FindObjectOfType<DialogoManager>();

    }


    public void ShowQuestText(string questText)
    {
        string[] dialogLines = new string[]
        {
            questText

        };
        manager.ShowDialog(dialogLines);
    }

}
