using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bbutton : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    ButtonSensor buttonSensor;
    Animator anim; 


    private void Start()
    {
        anim = GetComponent<Animator>();
        buttonSensor = FindAnyObjectByType<ButtonSensor>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            spriteRenderer.enabled = true;
            if (buttonSensor.isKeyboard)
            {
                anim.SetBool("isKeyboard", true);
                anim.SetBool("isController", false);
            }
            if(buttonSensor.isController) 
            {
                anim.SetBool("isKeyboard", false);
                anim.SetBool("isController", true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            spriteRenderer.enabled = false;
        }
    }
}
