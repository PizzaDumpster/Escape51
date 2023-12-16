using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public PlayerHealthController playerHealthController; 
    AudioSource audioSource; 
    public AudioClip healthPickupSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
        playerHealthController = GameObject.Find("Alien_Green").GetComponent<PlayerHealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(healthPickupSound, transform.position, 0.65f);
            playerHealthController.FillHealth();
            this.gameObject.SetActive(false);
        }
    }
}
