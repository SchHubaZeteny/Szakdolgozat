using System.Collections;
using UnityEngine;

public class ShootingEnemyProjectileController : MonoBehaviour
{
    private float speed = 7.0f;

    private float damage = 10.0f;

    private float delay = 0.3f;

    private bool canMove = false;

    public GameObject radius;

    public PlayerController player;

    public Vector2 pos;


    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        StartCoroutine(Delay());

        Destroy(gameObject, 10.0f);
    }

    void Update()
    {
        FollowPoint();
        RotateToPoint();
    }

    IEnumerator Delay()
    {
       yield return new WaitForSeconds(delay);
       canMove = true;
    }

    public void FollowPoint()
    {
        if (canMove)
        {
            Vector2 currentPosition = transform.position;

            Vector2 goal = (pos - currentPosition).normalized;

            Vector2 movement = goal * speed * Time.deltaTime;

            transform.position = currentPosition + movement;
        }
    }

    public void RotateToPoint()
    {
        Vector2 direction = (pos - (Vector2)transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerTriggerHitbox"))
        {
            player.TakingDamage(damage);
        }
    }
}
