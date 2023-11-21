 using System;
 using System.Collections;
 using System.Collections.Generic;
 using System.Reflection;
 using UnityEngine;
 using TMPro;
 using Image = UnityEngine.UI.Image;

 public class DialogueManager : MonoBehaviour
 {
    [Header("Components")]
    public Image actorImage;
    public TextMeshProUGUI messageText;
    public RectTransform backgroundBox;
    public GameObject dialogueBox;
    private PlayerManager player;
    int activeMessage = 0;
    public static bool isActive = false;

    [Header("IDs")]
    Message[] currentMessages;
    Actor[] currentActors;

    private void Start()
    {
        player = FindObjectOfType<PlayerManager>();
    }

    //Update is called once per frame
    void Update()
     {
        if (Input.GetMouseButtonDown(0) && isActive == true)
         {
             NextMessage();
         }
     }

     public void OpenDialogue(Message[] messages, Actor[] actors)
     {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        player.canMove = false;
        isActive = true;
        Debug.Log("Dialogue Load: " + messages.Length);
        DisplayMessage();
     }

    void DisplayMessage()
    {
        dialogueBox.SetActive(true);
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorImage.sprite = actorToDisplay.sprite;
    }

    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            CloseMessage();
        }
    }

     void CloseMessage()
     {
        Debug.Log("Conversation ended.");
        isActive = false;
        player.canMove = true;
        dialogueBox.SetActive(false);
    }

 }
