using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{

    public Sprite[] staminaBarSprite; 
    public Image staminaBarImage; 
    private PlayerHealthController playerHealthController; 

    // Start is called before the first frame update
    void Start()
    {
        playerHealthController = FindObjectOfType<PlayerHealthController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        switch(playerHealthController.currentStamina){
            case 0:
                 staminaBarImage.sprite = staminaBarSprite[10]; 
                break;
            case 1:
                 staminaBarImage.sprite = staminaBarSprite[9]; 
                break;
            case 2:
                 staminaBarImage.sprite = staminaBarSprite[8]; 
                break;
            case 3:
                staminaBarImage.sprite = staminaBarSprite[7]; 
                break;
            case 4:
                 staminaBarImage.sprite = staminaBarSprite[6]; 
                break;
            case 5: 
                staminaBarImage.sprite = staminaBarSprite[5]; 
                break;
            case 6:
                staminaBarImage.sprite = staminaBarSprite[4]; 
                break;
            case 7:
                staminaBarImage.sprite = staminaBarSprite[3]; 
                break;
            case 8:
                staminaBarImage.sprite = staminaBarSprite[2]; 
                break;
            case 9:
                staminaBarImage.sprite = staminaBarSprite[1]; 
                break;
            case 10:
                staminaBarImage.sprite = staminaBarSprite[0]; 
                break;
        }
    }
}
