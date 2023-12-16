using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueTrigger : MonoBehaviour
{
    public BlueDialogue dialogue; 
    private bool wasNotTriggered;
    
    void Start(){
        wasNotTriggered = true; 
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player" && wasNotTriggered){
            FindObjectOfType<DialogueManager>().StartBlueDialogue(dialogue);
            wasNotTriggered = false; 
        }
    }

}
