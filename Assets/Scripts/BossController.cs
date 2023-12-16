using UnityEngine;

public class BossController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public float moveSpeed = 5f;
    public float attackRange = 1f;
    public float moveRange = 10f;

    //public Animator animator;

    private Transform target;
    private Rigidbody2D rb;

    private void Start()
    {
        currentHealth = maxHealth;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (target == null)
        {
            return;
        }
        if (Vector2.Distance(target.transform.position, this.transform.position) < moveRange)
        {
            // Move the boss towards the player if it's not in attack range
            float distanceToPlayer = Vector3.Distance(transform.position, target.position);
            if (distanceToPlayer > attackRange)
            {
                Vector3 direction = (target.position - transform.position).normalized;
                rb.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);
                //animator.SetTrigger("move");
            }
            else
            {
                //animator.SetTrigger("attack");
                // Add any additional code for boss attack here
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            //animator.SetTrigger("hurt");
        }
    }

    private void Die()
    {
        //animator.SetTrigger("death");
        // Add any additional code for boss death here
        Destroy(gameObject, 2f); // Destroy the boss after 2 seconds
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(Random.Range(1, 20));
        }
    }
}
