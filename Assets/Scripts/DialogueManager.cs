using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    EventSystem eventSystem; 

    public Canvas dialogueCanvas;
    public TMP_Text nameText; 
    public TMP_Text dialogueText;

    public Button dialogueButton;
    public GameObject dialogueGOBuggon; 

    private Queue<string> sentences;
    public GameObject doorOne; 

    private PlayerController playerController;




    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>(); 
        dialogueButton.onClick.AddListener(DisplayNextSentence);
        dialogueCanvas.gameObject.SetActive(false);
        sentences = new Queue<string>(); 
        eventSystem = EventSystem.current;
      
    }

    public void StartDialogue(Dialogue dialogue){
        playerController.isInUI = true; 
        dialogueCanvas.gameObject.SetActive(true);
        eventSystem.SetSelectedGameObject(null);
        eventSystem.SetSelectedGameObject(dialogueGOBuggon);
        

        nameText.text = dialogue.name; 

        sentences.Clear(); 

        foreach(string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }
            DisplayNextSentence();
    }
    public void DisplayNextSentence(){
        if(sentences.Count == 0){
            EndDialogue();
            return; 
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;

    }
    void EndDialogue(){
        dialogueCanvas.gameObject.SetActive(false);
        doorOne.gameObject.SetActive(false);
        playerController.isInUI = false; 
    }
    public void StartBlueDialogue(BlueDialogue dialogue){
        playerController.isInUI = true;
        playerController.hasRescuedBlue = true; 
        dialogueCanvas.gameObject.SetActive(true);
        eventSystem.SetSelectedGameObject(null);
        eventSystem.SetSelectedGameObject(dialogueGOBuggon);

        nameText.text = dialogue.name; 

        sentences.Clear(); 

        foreach(string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }
            DisplayNextSentence();
    }

}
