using UnityEngine;

public class OrbitalAbilityOrbController : MonoBehaviour
{
    private Vector2 playerCenter;
    private float xRad = 5.5f;
    private float yRad = 5.5f;
    private float rotatinSpeed = 1.5f;
    private float timer = 0.0f;
    private bool clockwise = true;

    private float damage = 10.0f;

    public PlayerController player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        timer += Time.deltaTime * rotatinSpeed;
        Rotate();
    }

    void Rotate()
    {
        if (clockwise)
        {
            float x = -Mathf.Cos(timer) * xRad;
            float z = Mathf.Sin(timer) * yRad;

            Vector2 pos = new Vector2(x, z);

            playerCenter = new Vector2(player.transform.position.x, player.transform.position.y);

            transform.position = pos + playerCenter;
        }
        else
        {
            float x = Mathf.Cos(timer) * xRad;
            float z = Mathf.Sin(timer) * yRad;

            Vector2 pos = new Vector2(x, z);

            playerCenter = new Vector2(player.transform.position.x, player.transform.position.y);

            transform.position = pos + playerCenter;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            if (other.GetComponent<EnemyStatController>().orbitalCanHit)
            {
                EnemyStatController enemy = other.GetComponent<EnemyStatController>();

                float random = Random.Range(0, 100);

                if (random <= player.criticalChance && player.criticalChance != 0 && enemy.orbitalCanHit)
                {
                    int critDamage = (int)(damage * 1.5f);
                    enemy.OrbitalAbilityDamage(critDamage);
                }
                else if(enemy.orbitalCanHit)
                {
                    enemy.OrbitalAbilityDamage(damage);
                }
            }
        }
    }
}
