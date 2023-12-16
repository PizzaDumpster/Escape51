using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class DoorOneSwitch : MonoBehaviour
{

    public UnityEvent doorswitch;

    // Start is called before the first frame update
    void Start()
    {
        if(doorswitch == null){
            doorswitch = new UnityEvent(); 
        }
        doorswitch.AddListener(DoorSwitch);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DoorSwitch(){
        Debug.Log("Door should open");
    }

    void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.CompareTag("Player") && (Input.GetButton("Fire1") || Input.GetButton("Fire1Controller")))
        {
            FindObjectOfType<AudioManager>().Play("CellDoor");
            doorswitch.Invoke();
        }
    }    

    public void OpenDoor(){
            doorswitch.Invoke();
    } 
}

