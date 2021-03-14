using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogoManager : MonoBehaviour
{
    public GameObject DialogBox;
    public Text DialogText;
    public bool dialogActive;
    public string[] DialogLine;
    public int CurrentDialogline;

    private PlayerControler playerController;


    private void Start()
    {
        playerController = FindObjectOfType<PlayerControler>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CurrentDialogline++;
        }
        if (CurrentDialogline >= DialogLine.Length)
        {
            dialogActive = false;
            DialogBox.SetActive(false);
            CurrentDialogline = 0;
            playerController.playerTalking = false;
        }
        else
        {
            DialogText.text = DialogLine[CurrentDialogline];
        }
    }

    public void ShowDialog(string[] lines)
    {
        dialogActive = true;
        DialogBox.SetActive(true);
        CurrentDialogline = 0;
        DialogLine = lines;
        playerController.playerTalking = true;

    }
}
