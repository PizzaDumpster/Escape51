using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static PlayerController;

public class ShowAmmo : MonoBehaviour
{
    public TMP_Text ammoCount;
    private PlayerController playerController;
   
    // Start is called before the first frame update
    void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
        ammoCount.text = "Ammo: " + playerController.uziBullets.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.currentWeapon == WeaponSelect.uzi)
        {
            ammoCount.text = "Ammo: " + playerController.uziBullets.ToString();
        }
        else
        {
            ammoCount.text = "Ammo: Infinite";
        }
    }
}
