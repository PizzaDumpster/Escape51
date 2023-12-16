using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDamage : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip damageSound;

    float timeAlive = 2f; 
    private PlayerHealthController playerHealthController; 

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerHealthController = GameObject.Find("Alien_Green").GetComponent<PlayerHealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        timeAlive -= Time.deltaTime; 
        if(timeAlive < 0){
            gameObject.SetActive(false);
            timeAlive = 2; 
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerHealthController.DamagePlayer(1);
            gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }
}
