using System.Collections;
using UnityEngine;

public class ShootingEnemyController : MonoBehaviour
{
    
    private float shootingCooldown = 7.0f;
    public bool canShoot = false;
    public bool shooting = false;
    private int numberOfProjectiles = 3;
    private float fireRate = 1.0f;

    public GameObject shootingRadiusPrefab;
    public GameObject shootingRadius;
    public GameObject projectilePrefab;
    public GameObject projectile;

    public EnemyStatController enemyStatController;

    void Start()
    {
        shootingRadius = Instantiate(shootingRadiusPrefab, transform.position, shootingRadiusPrefab.transform.rotation);
        shootingRadius.GetComponent<ShootingEnemyRadiusController>().shootingEnemy = gameObject;
        enemyStatController = GetComponent<EnemyStatController>();
    }

    public void Shoot()
    {
        if (canShoot)
        {
            StartCoroutine(Shooting());
        }
    }

    public IEnumerator Shooting()
    {
        if(canShoot && !shooting)
        {

            shooting = true;

            for (int i = 0; i < numberOfProjectiles; i++)
            {
                yield return new WaitForSeconds(fireRate);
                projectile = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
                Vector2 position = shootingRadius.GetComponent<ShootingEnemyRadiusController>().position;
                projectile.GetComponent<ShootingEnemyProjectileController>().pos = position;
            }

            StartCoroutine(ShootingCooldown());
        }
    }

    public IEnumerator ShootingCooldown()
    {
        yield return new WaitForSeconds(shootingCooldown);

        shooting = false;

        StartCoroutine(Shooting());
    }
}
