using UnityEngine;

public class BombEnemyExplosionController : MonoBehaviour
{
    public AudioClip explosionSound;

    public float damage = 50.0f;

    public PlayerController player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        SoundFXManager.instance.PlaySoundFXClip(explosionSound, 1.8f, 2.6f, transform, 1f);

        Destroy(gameObject,0.3f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerTriggerHitbox"))
        {
            player.TakingDamage(damage);
        }
    }
}
