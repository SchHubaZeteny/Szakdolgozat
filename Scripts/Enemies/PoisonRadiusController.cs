using System.Collections;
using UnityEngine;

public class PoisonRadiusController : MonoBehaviour
{
    public PlayerController player;

    private bool hittingPlayer = false;

    private float damage = 5.0f;

    private float damageCooldown = 0.5f;

    private float deathTimer = 5f;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        Destroy(gameObject, deathTimer);
    }

    public void DamagePlayer()
    {
        if (hittingPlayer)
        {
            player.TakingDamage(damage);

            StartCoroutine(DamageCooldown());
        }
    }

    public IEnumerator DamageCooldown()
    {
        yield return new WaitForSeconds(damageCooldown);
        DamagePlayer();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerTriggerHitbox"))
        {
            hittingPlayer = true;
            DamagePlayer();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PlayerTriggerHitbox"))
        {
            hittingPlayer = false;
        }
    }
}
