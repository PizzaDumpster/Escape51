using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoverY : MonoBehaviour
{
    Vector3 platformStartPosition;
    

    // Start is called before the first frame update
    void Start()
    {
      
        platformStartPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {


        transform.position = platformStartPosition + new Vector3(0, 2 * Mathf.Sin(Time.time));
    }
   
   
}
