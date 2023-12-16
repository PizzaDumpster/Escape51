using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TxtMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Random.Range(-10f, 10f), 10, 0) * Time.deltaTime;
    }
}
