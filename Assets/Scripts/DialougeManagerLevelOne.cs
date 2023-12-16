using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; 

public class DialougeManagerLevelOne : MonoBehaviour
{
    public Canvas dialogueCanvas;
    public TMP_Text nameText; 
    public TMP_Text dialogueText;

    public Button dialogueButton; 

    private Queue<string> sentences;

    private PlayerController playerController; 



    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>(); 
        dialogueButton.onClick.AddListener(DisplayNextSentence);
        dialogueCanvas.gameObject.SetActive(false);
        sentences = new Queue<string>(); 
    }

    public void StartDialogue(Dialogue dialogue){
        playerController.isInUI = true; 
        dialogueCanvas.gameObject.SetActive(true);

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
        playerController.isInUI = false; 
    }

}
