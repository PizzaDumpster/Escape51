using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndTrigger : MonoBehaviour
{
    public Dialogue dialogue; 
    private bool wasNotTriggered;
    private PlayerController playerController; 
    
    void Start(){
        playerController = FindObjectOfType<PlayerController>(); 
        wasNotTriggered = true; 
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player") && wasNotTriggered){
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            wasNotTriggered = false; 
            if(!playerController.hasRescuedBlue)
                wasNotTriggered = true; 
        }
    }

}



