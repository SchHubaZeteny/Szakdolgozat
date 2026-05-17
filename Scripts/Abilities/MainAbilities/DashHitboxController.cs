using UnityEngine;

public class DashHitboxController : MonoBehaviour
{
    public PlayerController player;

    private float damage = 10.0f;

    public AudioClip dashSound;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        SoundFXManager.instance.PlaySoundFXClip(dashSound, 0f, dashSound.length, transform, 1f);

        RotateToMouse();
    }

    void Update()
    {
        transform.position = player.transform.position;
    }

    public void RotateToMouse()
    {
        Vector3 mouseScreenPos = Input.mousePosition;

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);

        mouseWorldPos.z = transform.position.z;

        Vector2 direction = (mouseWorldPos - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
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
}
