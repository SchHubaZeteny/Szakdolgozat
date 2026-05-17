using UnityEngine;

public class BoomerangAbility : MonoBehaviour
{
    public BoomerangAbilityRadius boomerangRadius;

    public GameObject player;

    private Rigidbody2D rb;

    public Vector2 pos;

    public Vector2 currentPos;

    private float speed = 10.0f;

    private float rotationSpeed = 10.0f;

    public float damage = 5.0f;

    public bool comeBack = false;

    public GameMenuManager gameMenuManager;


    void Start()
    {
        boomerangRadius = GameObject.FindWithTag("BoomerangAbilityRadius").GetComponent<BoomerangAbilityRadius>();
        gameMenuManager = GameObject.FindWithTag("GameMenuManager").GetComponent<GameMenuManager>();
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        pos = boomerangRadius.position;
    }


    void Update()
    {
        if(!gameMenuManager.gameIsPaused)
        {
            transform.Rotate(0f, 0f, rotationSpeed, Space.Self);
        }
        currentPos = transform.position;
        FollowPoint();
    }

    public void FollowPoint()
    {
        if(comeBack)
        {
            FollowPlayer();
        }
        else
        {
            Vector2 currentPosition = transform.position;

            Vector2 goal = (pos - currentPosition).normalized;
            rb.AddForce(goal * speed * Time.deltaTime);

            Vector2 movement = goal * speed * Time.deltaTime;

            transform.position = currentPosition + movement;
        }
    }

    public void FollowPlayer()
    {
        Vector2 currentPosition = transform.position;

        Vector2 playerPosition = player.transform.position;

        Vector2 goal = (playerPosition - currentPosition).normalized;
        rb.AddForce(goal * speed * Time.deltaTime);

        Vector2 movement = goal * speed * Time.deltaTime;

        transform.position = currentPosition + movement;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BoomerangPoint"))
        {
            comeBack = true;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("PlayerPickUpHitbox") && comeBack)
        {
            Destroy(gameObject, 0.1f);
        }
    }
}
