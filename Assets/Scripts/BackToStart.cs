using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ToMainMenu());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ToMainMenu()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }
}
