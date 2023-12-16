using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip damageSound; 
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerController = FindAnyObjectByType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerController.playerHealthController.DamagePlayer(5);
        }
        this.gameObject.SetActive(false);
    }
}
