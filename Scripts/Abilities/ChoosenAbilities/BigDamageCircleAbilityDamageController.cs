using UnityEngine;

public class BigDamageCircleAbilityDamageController : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyStatController>().currentHealth = 0;
        }
    }
}
