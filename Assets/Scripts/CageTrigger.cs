using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CageTrigger : MonoBehaviour
{

    private PlayerController controller;
    private GameObject theCage;

    public TMP_Text endText;
    public bool alienCaptured;
    private float alienCapturedTimer;

    private void Start()
    {
        controller = GameObject.Find("Alien_Green").GetComponent<PlayerController>();
        theCage = GameObject.Find("AlienCage");
        endText.gameObject.SetActive(false);
        

    }

    void Update(){
        if(alienCaptured){
            alienCapturedTimer += Time.deltaTime; 
            if(alienCapturedTimer > 10){
                SceneManager.LoadScene(2);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            controller.playerRB.constraints = RigidbodyConstraints2D.FreezeAll;
            theCage.transform.position = controller.playerRB.position;
            endText.gameObject.SetActive(true);
            alienCaptured = true; 

        }
    }

}
