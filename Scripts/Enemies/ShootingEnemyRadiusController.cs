using UnityEngine;

public class ShootingEnemyRadiusController : MonoBehaviour
{
    public GameObject shootingEnemy;

    public EnemyStatController shootingEnemyStat;

    public GameObject player;

    public Vector2 position;

    private float shootingRadius = 50.0f;

    private bool getPoint = false;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        shootingEnemyStat = shootingEnemy.GetComponent<EnemyStatController>();
    }


    void FixedUpdate()
    {
        GetPoint();
        if(shootingEnemyStat.currentHealth > 0)
        {
            transform.position = shootingEnemy.transform.position;
        }
    }

    public void GetPoint()
    {
        if (getPoint && shootingEnemyStat.currentHealth > 0)
        {
            Vector2 center = shootingEnemy.transform.position;
            float radius = shootingRadius;


            position = GetPointOnCircumference(center, player.transform.position, radius);
        }
    }

    Vector2 GetPointOnCircumference(Vector2 center, Vector2 enemyPos, float radius)
    {
        float extraDistance = 100f;

        Vector2 direction = enemyPos - center;

        Vector2 offset = direction.normalized * (radius + extraDistance);

        return center + offset;
    }

    public void Death()
    {
        if (shootingEnemyStat.currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerTriggerHitbox") && shootingEnemy != null)
        {
            getPoint = true;
            shootingEnemy.GetComponent<ShootingEnemyController>().canShoot = true;
            shootingEnemy.GetComponent<ShootingEnemyController>().Shoot();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PlayerTriggerHitbox") && shootingEnemy != null)
        {
            getPoint = false;
            shootingEnemy.GetComponent<ShootingEnemyController>().canShoot = false;
        }
    }
}
