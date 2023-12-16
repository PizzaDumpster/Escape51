using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMaster : MonoBehaviour
{
    PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        Camera.main.transform.position = new Vector3(playerController.playerRB.transform.position.x, playerController.playerRB.transform.position.y, -10f);
    }
}