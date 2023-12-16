using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public AudioClip damageSound; 
    public Rigidbody2D enemySoldier;
    public Transform firePoint;
    public GameObject bullet;
    public float bulletSpeed;
    private bool m_FacingRight;
    public float fireRate = 1f;
    public float lastShot = 0f;
    public Transform playerTarget;
    AudioSource audioSource;
    public AudioClip enemyLazerSound;
    public int health = 10;
    public int detectDistance;
    LineRenderer lineRenderer; 

    private PlayerHealthController playerHealthController;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerHealthController = GameObject.Find("Alien_Green").GetComponent<PlayerHealthController>();
        playerController = FindObjectOfType<PlayerController>();
        lineRenderer = GetComponent<LineRenderer>();
        detectDistance = 15; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(playerTarget.transform.position, this.transform.position) < detectDistance)
        {
            if (Time.time > fireRate + lastShot)
            {
                audioSource.PlayOneShot(enemyLazerSound, 0.45f);
                GameObject clone = Instantiate(bullet, firePoint.position, firePoint.rotation);
                Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), enemySoldier.GetComponent<Collider2D>());
                Rigidbody2D shot = clone.GetComponent<Rigidbody2D>();
                if (!m_FacingRight) 
                { 
                    shot.AddForce(-transform.right * bulletSpeed, ForceMode2D.Impulse);
                    shot.transform.localScale = new Vector3(-1, 1,1);
                }
                else
                    shot.AddForce(transform.right * bulletSpeed, ForceMode2D.Impulse);
                Destroy(clone.gameObject, 1f);
                lastShot = Time.time;
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
            if (health <= 0)
            {
                FindObjectOfType<AudioManager>().Play("EnemyHit");
                gameObject.SetActive(false);
            }
                
        }
    }
    void OnDrawGizmosSelected()
    {
        Ray ray = new Ray(firePoint.transform.position, -transform.forward);
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectDistance);
        Gizmos.DrawLine(firePoint.position, playerTarget.position);
    }
}
