using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.Audio; 

public class MasterVolumer : MonoBehaviour
{
    public Slider audioSlider;
    public AudioMixer masterAudio; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMasterVolume(float value)
    {
        masterAudio.SetFloat("masterParam", audioSlider.value);
    }


}
