using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public void LevelOne()
    {
        SceneManager.LoadScene(1);
    }

    public void LevelTutorial() 
    { 
        SceneManager.LoadScene(5);
    }

    public void ControllerMap()
    {
        SceneManager.LoadScene(6);
    }
}
