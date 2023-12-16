using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    PlayerController controller;
    PlayerHealthController playerHealthController; 
    // Start is called before the first frame update
    void Start()
    {
        playerHealthController = FindAnyObjectByType<PlayerHealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealthController.currentHealth = 0;
        }
    }
}
