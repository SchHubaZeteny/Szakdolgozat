using UnityEngine;

public class LightningCastAbilityDamageController : MonoBehaviour
{
    public Vector2 enemyPos;
    private float damage = 15f;

    private float spawnOffset = 12f;

    public PlayerController player;

    public AudioClip electricSound;


    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        SoundFXManager.instance.PlaySoundFXClip(electricSound, 1.2f, 0.4f, transform, 1f);
        RotateToMouse();
        Destroy(gameObject, 0.4f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            EnemyStatController enemy = other.GetComponent<EnemyStatController>();

            float random = Random.Range(0, 100);

            if (random <= player.criticalChance && player.criticalChance != 0)
            {
                int critDamage = (int)(damage * 1.5f);
                enemy.TakeDamage(critDamage);
            }
            else
            {
                enemy.TakeDamage(damage);
            }
        }
    }

    public void RotateToMouse()
    {
        Vector2 direction = (enemyPos - (Vector2)transform.position).normalized;

        Vector2 spawnPosition = (Vector2)transform.position + (direction * spawnOffset);

        transform.position = spawnPosition;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
