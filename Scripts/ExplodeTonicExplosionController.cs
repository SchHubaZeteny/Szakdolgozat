using System.Collections;
using UnityEngine;

public class ExplodeTonicExplosionController : MonoBehaviour
{
    public AudioClip explosionSound;

    public PlayerController player;

    public PlayerProjectileManager manager;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        manager = GameObject.FindWithTag("PlayerProjectileManager").GetComponent<PlayerProjectileManager>();

        SoundFXManager.instance.PlaySoundFXClip(explosionSound, 1.8f, 2.6f, transform, 1f);

        Destroy(gameObject, 0.3f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            EnemyStatController enemy = other.GetComponent<EnemyStatController>();

            float random = Random.Range(0, 100);

            if (random <= player.criticalChance && player.criticalChance != 0)
            {
                int critDamage = (int)(manager.damage * 1.5f);
                enemy.TakeDamage(critDamage);
            }
            else
            {
                enemy.TakeDamage(manager.damage);
            }
        }
    }
}
