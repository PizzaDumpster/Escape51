using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UziPickup : MonoBehaviour
{
    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerController.uziBullets += 30; 
            playerController.hasUzi = true;
            this.gameObject.SetActive(false);
        }
    }
}
