using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables; 
using UnityEngine.SceneManagement; 

public class TimelinePlayer : MonoBehaviour
{

    private PlayableDirector director; 

    // Start is called before the first frame update
    void Start()
    {
        director = GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTimeline(){
        director.Play(); 
    }
}
