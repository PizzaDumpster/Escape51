using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class LevelThreeExit : MonoBehaviour
{
    private TimelinePlayer player;
    [SerializeField] GameObject playerGameObject; 

    // private PlayableDirector director; 
    //public GameObject controlPanel; 

     void Awake(){
        player = FindObjectOfType<TimelinePlayer>();
        
    //     director = GetComponent<PlayableDirector>();
    //     // director.played += Director_Played; 
    //     // director.stopped += Director_Stopped; 
     }

    // private void Director_Played(PlayableDirector obj){
    //     controlPanel.SetActive(false);
    // }

    // private void Director_Stopped(PlayableDirector obj){
    //     controlPanel.SetActive(true);
    // }

 

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Player"))
        {
            player.StartTimeline();
            playerGameObject.SetActive(false); 
        }
         
        
    }
}
