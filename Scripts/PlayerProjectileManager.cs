using System.Collections;
using UnityEngine;

public class PlayerProjectileManager : MonoBehaviour
{
    public int projectileCount = 0;
    private float reloadSpeed = 2f;
    public float damage = 7f;

    public GameObject projectilePrefab;

    public GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");

        if (MainManager.Instance != null)
        {
            reloadSpeed = MainManager.Instance.playerAttackSpeed == 0 ? reloadSpeed : MainManager.Instance.playerAttackSpeed;
            damage = MainManager.Instance.playerDamage == 0 ? damage : MainManager.Instance.playerDamage;
        }

        Shoot();
    }

    public void Shoot()
    {
        Instantiate(projectilePrefab, player.transform.position, projectilePrefab.transform.rotation);

        projectileCount++;
        if (projectileCount == 3)
        {
            projectileCount = 0;
        }

        StartCoroutine(ShootCooldown());
    }

    public IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(reloadSpeed);
        Shoot();
    }
}
