using System.Collections;
using UnityEngine;

public class DashController : MonoBehaviour
{
    [Header("Dash Settings")]
    public float dashSpeed = 20f;      
    public float dashDuration = 0.4f;  

    [Header("Links")]
    public Rigidbody2D playerRb;       
    public PlayerController player;    
    public GameObject dashHitboxPrefab;
    public GameObject dashHitbox;

    private Vector2 dashDirection;     
    private bool isDashing = false;
    public bool canDash;
    private float dashCooldown = 15.0f;
    public float dashCooldownLeft;

    private float hitboxBack = 1.0f;

    private float coolDownReduction;


    void Start()
    {
        playerRb = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();


        if (MainManager.Instance != null)
        {
            coolDownReduction = MainManager.Instance.playerCdr == 0 ? 0.0f : MainManager.Instance.playerCdr;

            if (coolDownReduction != 0)
            {
                dashCooldown = (int)(dashCooldown * (coolDownReduction / 100.0f));
            }
        }
        

        dashCooldownLeft = dashCooldown;
        canDash = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && !isDashing && canDash)
        {
            MainManager.Instance.useDashQuestProgress++;
            dashCooldownLeft = dashCooldown;
            StartCoroutine(Dash());
        }
    }

    void FixedUpdate()
    {
        if (isDashing)
        {
            playerRb.linearVelocity = dashDirection * dashSpeed;
        }
        
    }

    private IEnumerator Dash()
    {
        player.transform.GetChild(0).gameObject.SetActive(false);
        player.transform.GetChild(1).gameObject.SetActive(false);

        DashDirection();

        canDash = false;
        isDashing = true;
        player.isDashing = true;
        dashHitbox = Instantiate(dashHitboxPrefab, player.transform.position, dashHitboxPrefab.transform.rotation);
        
        yield return new WaitForSeconds(dashDuration);
        Destroy(dashHitbox);
        isDashing = false;
        player.isDashing = false;
        player.transform.GetChild(0).gameObject.SetActive(true);

        StartCoroutine(Cooldown());
        StartCoroutine(SecondsLeft());
        StartCoroutine(hitboxCooldown());
    }

    public void DashDirection()
    {
        Vector3 mouseScreenPos = Input.mousePosition;

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);

        mouseWorldPos.z = transform.position.z;

        Vector2 direction = (mouseWorldPos - player.transform.position).normalized;

        dashDirection = direction;
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    private IEnumerator SecondsLeft()
    {
        while (!canDash)
        {
            yield return new WaitForSeconds(1);
            dashCooldownLeft -= 1;
        }
    }

    private IEnumerator hitboxCooldown()
    {
        yield return new WaitForSeconds(hitboxBack);
        player.transform.GetChild(1).gameObject.SetActive(true);
    }
}
