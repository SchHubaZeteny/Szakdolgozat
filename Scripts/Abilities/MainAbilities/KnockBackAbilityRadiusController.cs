using UnityEngine;

public class KnockBackAbilityRadiusController : MonoBehaviour
{
    private float spawnOffset = 8f;

    public AudioClip knockbackSound;


    void Start()
    {
        SoundFXManager.instance.PlaySoundFXClip(knockbackSound, 0f, knockbackSound.length, transform, 1f);

        RotateToMouse();

        Destroy(gameObject, 0.4f);
    }

    public void RotateToMouse()
    {
        Vector2 mouseScreenPos = Input.mousePosition;

        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);

        Vector2 direction = (mouseWorldPos - (Vector2)transform.position).normalized;

        Vector2 spawnPosition = (Vector2)transform.position + (direction * spawnOffset);

        transform.position = spawnPosition;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyStatController>().KnockBack();
        }
    }
}
