using UnityEngine;
using UnityEngine.UI;

public class EnemySoldier : MonoBehaviour
{
    
    public AudioClip damageAudio; 
    public Canvas damageText;
    public Transform damageTextPoint;
    public float counter = 0;
    public GameObject uziDrop;
    public Rigidbody2D enemySoldier;
    public Transform firePoint;
    public GameObject bullet;
    public float bulletSpeed;
    private bool m_FacingRight;
    public float fireRate = 0.2f;
    public float lastShot = 0f;
    public Transform playerTarget;
    AudioSource audioSource;
    public AudioClip enemyLazerSound;
    public int health = 3;
    const string c_bullet = "Bullet";
    const string c_player = "Player";
    const string c_alienGreen = "Alien_Green";
    public bool isDead;
    public bool isDropped;
    public CapsuleCollider2D enemyCollider;
    public Animator anim;
    private PlayerHealthController playerHealthController;
    private PlayerController playerController;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        enemyCollider = GetComponent<CapsuleCollider2D>();
        audioSource = GetComponent<AudioSource>();
        playerHealthController = GameObject.Find(c_alienGreen).GetComponent<PlayerHealthController>();
        playerController = FindObjectOfType<PlayerController>();
        slider.value = health;
        isDead = false;
        isDropped = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (!isDead)
        {
            if (Vector2.Distance(playerTarget.transform.position, this.transform.position) < 10)
            {
                if (Time.time > fireRate + lastShot)
                {
                    audioSource.PlayOneShot(enemyLazerSound, 0.45f);
                    GameObject clone = Instantiate(bullet, firePoint.position, firePoint.rotation);
                    Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), enemySoldier.GetComponent<Collider2D>());
                    Rigidbody2D shot = clone.GetComponent<Rigidbody2D>();
                    if (!m_FacingRight)
                        shot.AddForce(-transform.right * bulletSpeed, ForceMode2D.Impulse);
                    else
                        shot.AddForce(transform.right * bulletSpeed, ForceMode2D.Impulse);
                    Destroy(clone.gameObject, 1f);
                    lastShot = Time.time;
                }
            }
        }
        else
        {
            counter += Time.deltaTime;
            anim.Play("isDead");
            if (counter >= 0.5f && !isDropped)
            {
                gameObject.SetActive(false);
                slider.gameObject.SetActive(false);
                int dropchance = Random.Range(0, 3);
                switch (dropchance)
                {
                    case 0:
                        Instantiate(uziDrop, this.transform.position, this.transform.rotation);
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                }
                isDropped = true;
            }
        }
    }

    public void TakeDamage()
    {
        FindObjectOfType<AudioManager>().Play("EnemyHit");
        health--;
        slider.value = health;
        Canvas holder = Instantiate(damageText, damageTextPoint.position, Quaternion.identity, transform);
        Destroy(holder.gameObject, 0.25f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == c_bullet)
        {

            TakeDamage();
            if (health <= 0)
            {
                isDead = true;
                enemyCollider.enabled = false;
                slider.gameObject.SetActive(false); 
            }
        }
        if (other.gameObject.tag == c_player)
        {
            playerHealthController.DamagePlayer(1);
            TakeDamage();
            
        }
    }
}
