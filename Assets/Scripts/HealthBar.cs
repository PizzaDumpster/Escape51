using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class HealthBar : MonoBehaviour
{

    public Sprite[] healthBarSprite; 
    public Image healthBarImage; 
    private PlayerHealthController playerHealthController; 

    // Start is called before the first frame update
    void Start()
    {
        playerHealthController = FindObjectOfType<PlayerHealthController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        switch(playerHealthController.currentHealth){
            case 0:
                 healthBarImage.sprite = healthBarSprite[10]; 
                break;
            case 1:
                 healthBarImage.sprite = healthBarSprite[9]; 
                break;
            case 2:
                 healthBarImage.sprite = healthBarSprite[8]; 
                break;
            case 3:
                healthBarImage.sprite = healthBarSprite[7]; 
                break;
            case 4:
                 healthBarImage.sprite = healthBarSprite[6]; 
                break;
            case 5: 
                healthBarImage.sprite = healthBarSprite[5]; 
                break;
            case 6:
                healthBarImage.sprite = healthBarSprite[4]; 
                break;
            case 7:
                healthBarImage.sprite = healthBarSprite[3]; 
                break;
            case 8:
                healthBarImage.sprite = healthBarSprite[2]; 
                break;
            case 9:
                healthBarImage.sprite = healthBarSprite[1]; 
                break;
            case 10:
                healthBarImage.sprite = healthBarSprite[0]; 
                break;
        }
    }
}
