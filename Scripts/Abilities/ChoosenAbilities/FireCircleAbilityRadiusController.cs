using UnityEngine;

public class FireCircleAbilityRadiusController : MonoBehaviour
{
    public AudioClip fireSound;

    private float damage = 5;

    public PlayerController player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        SoundFXManager.instance.PlaySoundFXClip(fireSound, 0f, 1f, transform, 1f);

        Destroy(gameObject, 0.4f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyStatController enemy = other.GetComponent<EnemyStatController>();

            float random = Random.Range(0, 100);

            if (random <= player.criticalChance && player.criticalChance != 0)
            {
                int critDamage = (int)(damage * 1.5f);
                enemy.FireCircle(critDamage);
            }
            else
            {
                enemy.FireCircle(damage);
            }
        }
    }
}
