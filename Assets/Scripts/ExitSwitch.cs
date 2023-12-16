using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 

public class ExitSwitch : MonoBehaviour
{
    private PlayerController playerController; 
    public UnityEvent doorSwitchExit;
    [SerializeField] private Canvas canvas; 

    // Start is called before the first frame update
    void Start()
    {
        if(doorSwitchExit == null){
            doorSwitchExit = new UnityEvent(); 
        }
        doorSwitchExit.AddListener(DoorSwitch1);
        playerController = FindObjectOfType<PlayerController>(); 
        canvas.gameObject.SetActive(false);
    }
    

    // Update is called once per frame
    void Update()
    {
        if(playerController.hasRescuedBlue){
            canvas.gameObject.SetActive(false);
        }
    }

    void DoorSwitch1(){
        if(playerController.hasRescuedBlue){
            Debug.Log("you have escaped");
            SceneManager.LoadScene(3);
        }else{
            canvas.gameObject.SetActive(true);
        }
        
    }

    void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.CompareTag("Player") && (Input.GetButton("Fire1") || Input.GetButton("Fire1Controller")))
        {
            FindObjectOfType<AudioManager>().Play("CellDoor");
            doorSwitchExit.Invoke();
        }
    }    

    public void OpenDoor(){
            doorSwitchExit.Invoke();
    } 
}