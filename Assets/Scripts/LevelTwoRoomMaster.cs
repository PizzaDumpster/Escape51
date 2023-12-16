using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoRoomMaster : MonoBehaviour
{
    public Transform targetPlayer; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.transform.position = new Vector3( targetPlayer.transform.position.x, targetPlayer.transform.position.y, -10f); 
    }
}
