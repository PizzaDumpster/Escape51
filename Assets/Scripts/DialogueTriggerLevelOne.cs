using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerLevelOne : MonoBehaviour
{
    public Dialogue dialogue; 
    private bool wasNotTriggered;
    
    
    void Start(){
        
        wasNotTriggered = true; 
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player" && wasNotTriggered){
            FindObjectOfType<DialougeManagerLevelOne>().StartDialogue(dialogue);
            wasNotTriggered = false; 
           
        }
    }

}
