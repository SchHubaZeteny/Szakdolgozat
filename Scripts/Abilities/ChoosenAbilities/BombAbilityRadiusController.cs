using UnityEngine;

public class BombAbilityRadiusController : MonoBehaviour
{
    public AudioClip explosionSound;

    public PlayerController player;

    private float damage = 15.0f;

    void Start()
    {
        SoundFXManager.instance.PlaySoundFXClip(explosionSound, 1.8f, 2.6f, transform, 1f);
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

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
            other.GetComponent <EnemyStatController>().Slowed();
        }
    }
}
