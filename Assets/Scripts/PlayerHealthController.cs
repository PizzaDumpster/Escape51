using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip hurtSound;

    PlayerController playerController;
    public int currentHealth;
    public int maxHealth = 10;

    public float invincibilityLength;
    private float invincCounter;

    public float flashLength;
    private float flashCounter;
    public int currentStamina;
    public int maxStamina = 10;

    SpriteRenderer spriteRenderer; 

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        currentStamina = maxStamina; 
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DamagePlayer(int damageAmount)
    {
        if (!playerController.isRolling)
        {
            audioSource.PlayOneShot(hurtSound, 0.45f);
            currentHealth -= damageAmount;
            StartCoroutine(DamageColor()); 

            if (currentHealth <= 0)
            {
                currentHealth = 0;

            }
        }



    }
    public void FillHealth()
    {
        currentHealth = maxHealth;

    }

    public void FillStamina(){
        if(currentStamina < 10)
            currentStamina++; 
    }
    public void ReduceStamina(){
        if(currentStamina > 0)
            currentStamina -= 1; 
    }

    public IEnumerator DamageColor()
    {
        for (int x = 0; x < 5; x++)
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
