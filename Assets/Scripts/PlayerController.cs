using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public enum WeaponSelect
    {
        lazer,
        uzi
    }
    public WeaponSelect currentWeapon = WeaponSelect.lazer;

    [SerializeField] ButtonSensor buttonSensor;
    EventSystem eventSystem;
    AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip lazerGunSound;
    public AudioClip uziGunSound;
    public Animator anim;


    public Rigidbody2D playerRB;
    public GameObject laserShot;
    public GameObject uziShot;
    public Transform firePoint;
    public Transform groundCheck;
    public Transform ceilingCheck;
    public LayerMask whatIsGround;
    public TMP_Text deathText;

    public Canvas pauseCanvas;
    public GameObject pauseSlider;
    private DialogueManager dialogueManager;

    public Vector2 direction;

    public float bulletSpeed = 100f;
    public const float gravity = -9.81f;
    public float playerVelocity;

    public float moveSpeed;

    public int jumpCounter;
    public float jumpForce;
    public int maxVelocity;

    public float fireRate = 0.3f;
    public float lastShot = 0f;
    public bool canShoot = false;
    public bool isRolling;
    public bool isFalling;
    public float canRollCoolDown;
    public bool isFacingRight;
    public bool canRoll;
    public float canRollTimer;
    public float canRollTimeLeft = 1f;

    public bool isDead;
    public bool isInUI;
    public PlayerHealthController playerHealthController;
    public float isDeadCounter;

    public float inAirCounter;

    int activeSceneIndex;
    public bool hasRescuedBlue;
    public bool isGrounded;
    public bool isStanding;
    public bool standBlocked;
    public float staminaTimer = 1f;
    public float fillStaminaTimer = 1f;
    public bool isPaused;
    public bool isWallSliding;
    public bool hasUzi;
    public int uziBullets = 0;

    const string c_alienGreen = "Alien_Green";
    const string c_jump = "Jump";
    const string c_jumpController = "JumpController";
    const string c_isDead = "isDead";
    const string c_fire2 = "Fire2";
    const string c_fire3 = "Fire3";
    const string c_fire2Controller = "Fire2Controller";
    const string c_fire3Controller = "Fire3Controller";
    const string c_start = "Start";
    const string c_horizontal = "HorizontalKeyboard";
    const string c_horizontalController = "HorizontalController";
    const string c_isWalking = "isWalking";
    const string c_isRolling = "isRolling";
    const string c_rightBumper = "RightBumper";
    const string c_leftBumper = "LeftBumper";
    const string c_rightTrigger = "RightTrigger";
    const string c_isShootingLaser = "isShootingLazer";
    const string c_isShootingUzi = "isShootingUzi";


    // Start is called before the first frame update
    void Start()
    {

        audioSource = GetComponent<AudioSource>();
        hasRescuedBlue = false;
        activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        isInUI = false;
        jumpCounter = 0;
        isDeadCounter = 0;
        canRoll = true;
        isPaused = false;
        canRollCoolDown = 0;
        canRollTimer = canRollTimeLeft;
        isDead = false;
        playerHealthController = GameObject.Find(c_alienGreen).GetComponent<PlayerHealthController>();
        anim.SetBool(c_isDead, false);
        pauseCanvas.gameObject.SetActive(false);
        eventSystem = EventSystem.current;
        hasUzi = false;
        maxVelocity = 20;
        isStanding = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPaused)
        {
            if (!isInUI)
            {
                if (!isDead)
                {
                    playerRB.velocity = Vector3.ClampMagnitude(playerRB.velocity, maxVelocity);
                    staminaTimer -= Time.deltaTime;
                    fillStaminaTimer -= Time.deltaTime;
                    standBlocked = Physics2D.Raycast(ceilingCheck.position, Vector2.up, 1f);
                    isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, whatIsGround);

                    if (buttonSensor.isKeyboard)
                    {
                        playerRB.velocity = new Vector2(Input.GetAxis(c_horizontal) * moveSpeed, playerRB.velocity.y);
                    }
                    if (buttonSensor.isController)
                    {
                        playerRB.velocity = new Vector2(Input.GetAxis(c_horizontalController) * moveSpeed, playerRB.velocity.y);
                    }
                    if (playerRB.velocity.x > 1 || playerRB.velocity.x < -1)
                    {
                        anim.SetBool(c_isWalking, true);
                    }
                    else
                    {
                        anim.SetBool(c_isWalking, false);
                    }
                    if (playerRB.velocity.x > 0 && isFacingRight)
                    {
                        Flip();
                    }
                    else if (playerRB.velocity.x < 0 && !isFacingRight)
                    {
                        Flip();
                    }

                    if (Input.GetButtonDown(c_jump) && jumpCounter < 2 && playerHealthController.currentStamina > 0)
                    {
                        anim.SetBool("isJumping", true);
                        audioSource.PlayOneShot(jumpSound, 0.35f);
                        playerHealthController.ReduceStamina();
                        playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
                    }
                    if (Input.GetButtonDown(c_jumpController) && jumpCounter < 2 && playerHealthController.currentStamina > 0)
                    {
                        anim.SetBool("isJumping", true);
                        audioSource.PlayOneShot(jumpSound, 0.35f);
                        playerHealthController.ReduceStamina();
                        playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
                    }
                    if ((Input.GetButtonUp(c_jump) && !isGrounded) || (Input.GetButtonUp(c_jumpController) && !isGrounded))
                    {
                        playerRB.velocity = new Vector2(playerRB.velocity.x, playerRB.velocity.y * 0.5f);
                    }
                    else if (isGrounded)
                    {
                        jumpCounter = 0;

                    }
                    if (Input.GetButtonUp(c_jump) || Input.GetButtonUp(c_jumpController))
                    {
                        jumpCounter++;
                    }
                    if (currentWeapon == WeaponSelect.lazer)
                    {
                        if ((System.Convert.ToBoolean(Input.GetAxis(c_rightTrigger)) && !isRolling) || (System.Convert.ToBoolean(Input.GetAxis("Mouse0")) && !isRolling))
                        {
                            anim.SetBool(c_isShootingLaser, true);
                            if (Time.time > fireRate + lastShot)
                            {
                                GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject();
                                if (bullet != null)
                                {
                                    bullet.transform.position = firePoint.transform.position;
                                    bullet.transform.rotation = firePoint.transform.rotation;
                                    bullet.SetActive(true);
                                    if (!isFacingRight)
                                    {
                                        audioSource.PlayOneShot(lazerGunSound, 0.35f);
                                        bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletSpeed, ForceMode2D.Impulse);
                                    }
                                    else
                                    {
                                        audioSource.PlayOneShot(lazerGunSound, 0.35f);
                                        bullet.GetComponent<Rigidbody2D>().AddForce(-transform.right * bulletSpeed, ForceMode2D.Impulse);
                                    }
                                }
                                lastShot = Time.time;
                            }
                        }
                        else
                        {
                            anim.SetBool(c_isShootingLaser, false);
                        }
                    }
                    if (currentWeapon == WeaponSelect.lazer)
                    {
                        anim.SetBool(c_isShootingUzi, false);
                    }
                    if (currentWeapon == WeaponSelect.uzi && (!hasUzi || uziBullets <= 0))
                    {
                        currentWeapon = WeaponSelect.lazer;
                    }
                    if (currentWeapon == WeaponSelect.uzi && hasUzi && uziBullets > 0)
                    {
                        if ((System.Convert.ToBoolean(Input.GetAxis(c_rightTrigger)) && !isRolling) || (System.Convert.ToBoolean(Input.GetAxis("Mouse0")) && !isRolling))
                        {
                            anim.SetBool(c_isShootingUzi, true);
                            if (Time.time > 0.05 + lastShot)
                            {
                                GameObject bullet = ObjectPoolerUzi.SharedInstance.GetPooledObject();
                                if (bullet != null)
                                {
                                    bullet.transform.position = firePoint.transform.position;
                                    bullet.transform.rotation = firePoint.transform.rotation;
                                    bullet.SetActive(true);
                                    if (!isFacingRight)
                                    {
                                        audioSource.PlayOneShot(uziGunSound, 0.35f);
                                        bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletSpeed, ForceMode2D.Impulse);
                                        bullet.transform.localScale = new Vector3(1, bullet.transform.localScale.y, bullet.transform.localScale.z);
                                        uziBullets--;
                                    }
                                    else
                                    {
                                        audioSource.PlayOneShot(uziGunSound, 0.35f);
                                        bullet.GetComponent<Rigidbody2D>().AddForce(-transform.right * bulletSpeed, ForceMode2D.Impulse);
                                        bullet.transform.localScale = new Vector3(-1, bullet.transform.localScale.y, bullet.transform.localScale.z);
                                        uziBullets--;
                                    }
                                }
                                lastShot = Time.time;
                            }
                        }
                        else
                        {
                            anim.SetBool(c_isShootingUzi, false);
                        }
                    }
                    if (Input.GetButtonDown(c_rightBumper) || Input.GetKeyDown(KeyCode.E))
                    {
                        currentWeapon++;
                        if ((int)currentWeapon >= 2)
                        {
                            currentWeapon = WeaponSelect.lazer;
                        }
                    }
                    if (Input.GetButtonDown(c_leftBumper) || Input.GetKeyDown(KeyCode.Q))
                    {
                        currentWeapon--;
                        if ((int)currentWeapon <= -1)
                        {
                            currentWeapon = WeaponSelect.uzi;
                        }
                    }
                    if (Input.GetButtonUp(c_fire2) || Input.GetButtonUp(c_fire2Controller))
                    {
                        playerHealthController.ReduceStamina();
                        playerHealthController.ReduceStamina();
                        canRollTimer = canRollTimeLeft;
                    }
                    if ((Input.GetButton(c_fire2) && canRollTimer > 0 && canRollCoolDown < 0 && playerHealthController.currentStamina > 0) ||
                        (Input.GetButton(c_fire2Controller) && canRollTimer > 0 && canRollCoolDown < 0 && playerHealthController.currentStamina > 0))
                    {
                        canRollTimer -= Time.deltaTime;
                        anim.SetBool(c_isRolling, true);

                        isRolling = true;
                        isStanding = false;
                        if (canRollTimer < 0)
                        {
                            canRollCoolDown = 1f;
                            canRollTimer = canRollTimeLeft;
                        }
                    }
                    else if (!standBlocked)
                    {
                        canRollCoolDown -= Time.deltaTime;
                        anim.SetBool(c_isRolling, false);
                        isRolling = false;
                        isStanding = true;
                    }
                    if ((Input.GetButton(c_fire3) && playerHealthController.currentStamina > 0)
                        || (Input.GetButton(c_fire3Controller) && playerHealthController.currentStamina > 0))
                    {
                        if (staminaTimer < 0)
                        {
                            playerHealthController.ReduceStamina();
                            staminaTimer = 0.5f;
                        }
                        moveSpeed = 10f;
                    }
                    else
                    {
                        moveSpeed = 8f;
                    }
                    if (fillStaminaTimer < 0)
                    {
                        playerHealthController.FillStamina();
                        fillStaminaTimer = 0.5f;
                    }
                    if (standBlocked && !isStanding)
                    {
                        anim.SetBool(c_isRolling, true);
                    }
                    if (playerRB.velocity.y < -1f)
                    {
                        isFalling = true;
                    }
                    else
                    {
                        isFalling = false;
                    }
                    if (isFalling)
                    {
                        anim.SetBool("isJumping", false);
                        anim.SetBool("isFalling", true);
                    }
                    else
                    {
                        anim.SetBool("isFalling", false);
                    }
                }
            }
        }
        if (Input.GetButtonDown(c_start))
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                eventSystem.SetSelectedGameObject(pauseSlider);
            }
        }
        if (isPaused)
        {
            Time.timeScale = 0;
            pauseCanvas.gameObject.SetActive(true);
            isInUI = true;
        }
        else
        {
            Time.timeScale = 1;
            pauseCanvas.gameObject.SetActive(false);
            isInUI = false; 
        }

        if (playerHealthController.currentHealth <= 0)
        {
            isDead = true;
            anim.SetBool(c_isDead, true);
        }

        if (isDead == true)
        {
            isDeadCounter += Time.deltaTime;
            deathText.transform.position = playerRB.transform.position;
            deathText.gameObject.SetActive(true);
            playerRB.constraints = RigidbodyConstraints2D.FreezeAll;
            if (isDeadCounter > 5)
            {
                SceneManager.LoadScene(activeSceneIndex);
            }
        }
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    void OnDrawGizmos()
    {
        // Draws a 5 unit long red line in front of the object
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(Vector3.up) * 1f;
        Gizmos.DrawRay(ceilingCheck.position, direction);
    }

}
