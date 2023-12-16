using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RollOnlyZone : MonoBehaviour
{
    PlayerController playerController; 
    // Start is called before the first frame update
    void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerController.anim.SetBool("isRolling", true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerController.anim.SetBool("isRolling", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerController.anim.SetBool("isRolling", false);
        }
    }
}
