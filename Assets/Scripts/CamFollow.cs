using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    
    private PlayerController playerController;

    public BoxCollider2D boundsBox; 

    public Transform player;

    private float halfHeight, halfWidth;

    public Transform[] roomCamSpot;

    public int roomNumber;
    public int nextRoom;
    public int backRoom;

    public float xPos, yPos, zPos;

    private void Start()
    {
        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;

        playerController = GetComponent<PlayerController>();

        roomNumber = 0;
        nextRoom = roomNumber + 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D other)
        {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.position = Vector2.Lerp(roomCamSpot[roomNumber].transform.position, roomCamSpot[nextRoom].transform.position, 0.5f);
            roomNumber++;
        }
            
            
        }
}