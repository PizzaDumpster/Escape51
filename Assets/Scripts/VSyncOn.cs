using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VSyncOn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
