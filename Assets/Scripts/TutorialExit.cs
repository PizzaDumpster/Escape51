using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialExit : MonoBehaviour
{
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && (Input.GetButton("Fire1") || Input.GetButton("Fire1Controller")))
        {
            SceneManager.LoadScene(0);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && (Input.GetButton("Fire1") || Input.GetButton("Fire1Controller")))
        {
            SceneManager.LoadScene(0);

        }
    }
}
