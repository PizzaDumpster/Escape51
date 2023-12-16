using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    [SerializeField] GameObject enemyBullet;
    [SerializeField] Transform firePoint;
    [SerializeField] Transform playerTarget;
    [SerializeField] float fireRateCoolDown;
    public AudioClip damageAudio; 
    AudioSource audioSource;
    public AudioClip enemyLazerSound;
    PlayerController playerController;
    public GameObject explosion;
    public int health = 3;
    

    // Start is called before the first frame update
    void Start()
    {
        
        playerController = FindObjectOfType<PlayerController>();
        audioSource = GetComponent<AudioSource>();
        fireRateCoolDown = 2f;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (!playerController.isInUI)
        {
            if (Vector2.Distance(playerTarget.transform.position, this.transform.position) < 10)
            {
                if (fireRateCoolDown > 0)
                {
                    fireRateCoolDown -= Time.deltaTime;
                    if (fireRateCoolDown < 0)
                    {
                        audioSource.PlayOneShot(enemyLazerSound, 0.45f);
                        Instantiate(enemyBullet, firePoint.position, firePoint.rotation);
                        fireRateCoolDown = 1f;

                    }
                }
            }
        }
    }

    void TakeDamage()
    {
        FindObjectOfType<AudioManager>().Play("EnemyHit");
        health--;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            TakeDamage();
            if(health <= 0)
            {
                AudioSource.PlayClipAtPoint(damageAudio, firePoint.position);
                GameObject holder = Instantiate(explosion, this.transform.position + new Vector3(0, 1.5f, 0), this.transform.rotation) as GameObject;
                this.gameObject.SetActive(false);
                Destroy(holder, 1f);
                
            }
        }
    }
}
