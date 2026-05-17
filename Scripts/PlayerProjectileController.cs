using UnityEngine;

public class PlayerProjectileController : MonoBehaviour
{
    private float projectileSpeed = 20f;
    private Vector2 direction;
    private int count;

    private float damage;

    public PlayerController player;

    public PlayerProjectileManager manager;

    public ChainLightningAbilityController chainLightningAbilityController;
    public GameObject abilityObject;

    public GameObject explodeTonicExplosionPrefab;

    Vector2 playerPos;
    Vector2 goal;

    public GameObject chainLightningEffect;
    public GameObject beenStruck;

    public AudioClip shootSound;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        manager = GameObject.FindWithTag("PlayerProjectileManager").GetComponent<PlayerProjectileManager>();

        SoundFXManager.instance.PlaySoundFXClip(shootSound, 0f, shootSound.length, transform, 0.6f);

        damage = manager.damage;

        abilityObject = GameObject.FindWithTag("ChainLightningAbility");

        if (abilityObject != null)
        {
            chainLightningAbilityController = abilityObject.GetComponent<ChainLightningAbilityController>();
        }

        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        count = manager.projectileCount;

        RotateToMouse();

        playerPos = player.transform.position;

        goal = (direction - playerPos).normalized;

        Destroy(gameObject, 5.0f);
    }


    void Update()
    {
        MoveToCursor();
    }

    public void MoveToCursor()
    {
        Vector2 currentPosition = transform.position;

        Vector2 movement = goal * projectileSpeed * Time.deltaTime;

        transform.position = currentPosition + movement;
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
        if (other.CompareTag("Enemy"))
        {
            EnemyStatController enemy = other.GetComponent<EnemyStatController>();

            float random = Random.Range(0, 100);

            if (random <= player.criticalChance && player.criticalChance != 0)
            {
                int critDamage = (int)(damage * 1.5f);
                enemy.TakeDamage(critDamage);

                if (player.usingLifestealTonic)
                {
                    int healAmount = (int)((damage * 1.5f) * 0.1f);

                    player.Heal(healAmount);
                }
            }
            else
            {
                enemy.TakeDamage(damage);

                if (player.usingLifestealTonic)
                {
                    int healAmount = (int)(damage * 0.1f);

                    player.Heal(healAmount);
                }
            }

            if (player.usingExplodeTonic && count == 2)
            {
                Instantiate(explodeTonicExplosionPrefab, transform.position, explodeTonicExplosionPrefab.transform.rotation);
            }

            if (chainLightningAbilityController != null)
            {
                if (other.CompareTag("Enemy") && chainLightningAbilityController.canChainLight)
                {
                    Instantiate(beenStruck, other.transform);
                    chainLightningEffect.GetComponent<ChainLightningController>().amountToChain = chainLightningAbilityController.amountToChain;
                    Instantiate(chainLightningEffect, other.transform.position, Quaternion.identity);
                    chainLightningAbilityController.canChainLight = false;
                }
            }

            Destroy(gameObject);
        }

        if (other.CompareTag("Obstacle"))
        {
            if (player.usingExplodeTonic && count == 2)
            {
                Instantiate(explodeTonicExplosionPrefab, transform.position, explodeTonicExplosionPrefab.transform.rotation);
            }

            Destroy(gameObject);
        }
    }

}
