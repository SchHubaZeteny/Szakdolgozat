using System.Collections;
using UnityEngine;

public class EnemyStatController : MonoBehaviour
{
    [Header("Stats")]
    public float maxHealth;
    public float currentHealth;
    public float damage;
    public float maxSpeed;
    public float speed;
    private float coordinate;
    private float goldChance;
    public bool isSummoned = false;
    private Vector2 pos;
    private bool isDead = false;

    [Header("Enemy types")]
    public bool simpleEnemy = false;
    public bool summonedEnemy = false;
    public bool fastEnemy = false;
    public bool mediumEnemy = false;
    public bool summoningEnemy = false;
    public bool bombEnemy = false;
    public bool poisonousEnemy = false;
    public bool shootingEnemy = false;

    [Header("KnockbackAbility")]
    public bool knockedBack = false;
    private float knockBackForce = 25f;
    private float knockBackCooldown = 0.7f;
    private float knockBackWallDamage = 20f;

    [Header("FireCircleAbility")]
    private float fireCircleDamageCooldown = 1f;
    private int fireCircleDamageTimes = 4;

    public GameObject currentBlackHole;

    public PlayerController player;

    public bool flip;

    [Header("PickUpPrefabs")]
    public GameObject xpPrefab;
    public GameObject goldPrefab;
    public GameObject healPrefab;

    public GameObject poisionRadiusPrefab;

    public GameObject blackHole;

    private Rigidbody2D rb;

    [Header("OrbitalAbility")]
    private float orbitalDamageCooldown = 1.5f;
    public bool orbitalCanHit = true;

    [Header("BoomerangAbility")]
    private bool forth = false;
    private bool back = false;

    private float frozenCooldown = 5.0f;
    private float slowedCooldown = 3.0f;
    private float slowedPercent = 0.5f;

    private Animator animator;

    public SpriteRenderer render;


    void Start()
    {
        if (simpleEnemy)
        {
            maxHealth = 20.0f;
            damage = 3.0f;
            maxSpeed = 2.0f;
            coordinate = 0.25f;
            goldChance = 40.0f;
        } else if (summonedEnemy)
        {
            maxHealth = 10.0f;
            damage = 3.0f;
            maxSpeed = 2.0f;
            coordinate = 0.25f;
            isSummoned = true;
        }
        else if (fastEnemy)
        {
            maxHealth = 10.0f;
            damage = 2.0f;
            maxSpeed = 4.0f;
            coordinate = 0.15f;
            goldChance = 90.0f;
        } else if (mediumEnemy)
        {
            maxHealth = 50.0f;
            damage = 10.0f;
            maxSpeed = 1.3f;
            coordinate = 0.3f;
            goldChance = 60.0f;
        } else if (summoningEnemy)
        {
            maxHealth = 35.0f;
            damage = 8.0f;
            maxSpeed = 0.8f;
            coordinate = 0.25f;
            goldChance = 40.0f;
        } else if (bombEnemy)
        {
            maxHealth = 30.0f;
            damage = 5.0f;
            maxSpeed = 2.5f;
            coordinate = 0.25f;
            goldChance = 50.0f;
        } else if (poisonousEnemy)
        {
            maxHealth = 50.0f;
            damage = 6.0f;
            maxSpeed = 1.5f;
            coordinate = 0.3f;
            goldChance = 70.0f;
        } else if (shootingEnemy)
        {
            maxHealth = 35.0f;
            damage = 5.0f;
            maxSpeed = 2.5f;
            coordinate = 0.25f;
            goldChance = 50.0f;
        }

        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        speed = maxSpeed;
    }

    void Update()
    {
        pos = transform.position;
        FollowPlayer();
        FacePlayer();
    }

    public void FollowPlayer()
    {
        if (!knockedBack && currentBlackHole == null)
        {
            Vector2 currentPosition = transform.position;

            Vector2 playerPosition = player.transform.position;

            Vector2 direction = (playerPosition - currentPosition).normalized;

            rb.linearVelocity = direction * speed;

        }else if (!knockedBack && currentBlackHole != null)
        {
            Vector2 currentPosition = transform.position;

            Vector2 direction = ((Vector2)currentBlackHole.transform.position - currentPosition).normalized;

            rb.linearVelocity = direction * (speed / 3);
        }
    }

    public void Death()
    {
        isDead = true;

        MainManager.Instance.killEnemiesQuestProgress++;

        if (!isSummoned)
        {
            float randomPosX = Random.Range(-coordinate, coordinate);
            float randomPosY = Random.Range(-coordinate, coordinate);
            Vector2 randomPosXP = new Vector2(randomPosX, randomPosY);

            float randomPosX1 = Random.Range(-coordinate, coordinate);
            float randomPosY2 = Random.Range(-coordinate, coordinate);
            Vector2 randomPosGold = new Vector2(randomPosX1, randomPosY2);

            float randomPosX3 = Random.Range(-coordinate, coordinate);
            float randomPosY3 = Random.Range(-coordinate, coordinate);
            Vector2 randomPosHeal = new Vector2(randomPosX3, randomPosY3);

            Instantiate(xpPrefab, pos + randomPosXP, xpPrefab.transform.rotation);

            int randomGive = Random.Range(0, 100);

            if (randomGive <= goldChance)
            {
                if (player.usingGoldDropTonic)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        randomPosX1 = Random.Range(-coordinate, coordinate);
                        randomPosY2 = Random.Range(-coordinate, coordinate);
                        randomPosGold = new Vector2(randomPosX1, randomPosY2);
                        Instantiate(goldPrefab, pos + randomPosGold, goldPrefab.transform.rotation);
                    }
                }
                else
                {
                    Instantiate(goldPrefab, pos + randomPosGold, goldPrefab.transform.rotation);
                }
            }

            int rand = Random.Range(0, 100);
            if (rand <= 5)
            {
                Instantiate(healPrefab, pos + randomPosHeal, healPrefab.transform.rotation);
            }

            if (poisonousEnemy)
            {
                Instantiate(poisionRadiusPrefab, transform.position, poisionRadiusPrefab.transform.rotation);
            }
        }
                
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        if (isDead)
        {
            return;
        }

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Death();
        }
    }


    IEnumerator FrozenCooldown()
    {
        yield return new WaitForSeconds(frozenCooldown);
        render.color = new Color32(255, 255, 255, 255);
        animator.speed = 1;
        speed = maxSpeed;
    }

    public void Frozen()
    {
        render.color = new Color32(9, 121, 203, 255);
        speed = 0.0f;
        animator.speed = 0;
        StartCoroutine(FrozenCooldown());
    }

    IEnumerator SlowedCooldown()
    {
        yield return new WaitForSeconds(slowedCooldown);
        speed = maxSpeed;
    }

    public void Slowed()
    {
        speed = speed * slowedPercent;
        StartCoroutine(SlowedCooldown());
    }

    public void KnockBack()
    {
        knockedBack = true;
        Vector2 direction = (transform.position - player.transform.position).normalized;
        rb.linearVelocity = direction * knockBackForce;
        StartCoroutine(KnockBackCooldown());
    }

    public IEnumerator KnockBackCooldown()
    {
        yield return new WaitForSeconds(knockBackCooldown);
        rb.linearVelocity = Vector2.zero;
        knockedBack = false;
    }

    IEnumerator OrbitalCooldown()
    {
        yield return new WaitForSeconds(orbitalDamageCooldown);
        orbitalCanHit = true;
    }

    public void OrbitalAbilityDamage(float orbitalDamage)
    {
        orbitalCanHit = false;
        TakeDamage(orbitalDamage);

        StartCoroutine(OrbitalCooldown());
    }

    public void FireCircle(float fireCircleDamage)
    {
        render.color = new Color32(255, 90, 0, 255);
        StartCoroutine(FireCircleDamage(fireCircleDamage));
    }

    public IEnumerator FireCircleDamage(float fireCircleDamage)
    {
        int i = 0;
        while (i < fireCircleDamageTimes)
        {
            yield return new WaitForSeconds(fireCircleDamageCooldown);

            TakeDamage(fireCircleDamage);
            i++;
        }
        render.color = new Color32(255, 255, 255, 255);
    }

    public void InBlackHole(float blackHoleDamage)
    {
        StartCoroutine(BlackHoleDamage(blackHoleDamage));
    }

    public IEnumerator BlackHoleDamage(float blackHoleDamage)
    {
        while(currentBlackHole)
        {
            yield return new WaitForSeconds(1);
            TakeDamage(blackHoleDamage);
        }
    }

    public void FacePlayer()
    {
        Vector2 scale = transform.localScale;

        if(player.transform.position.x < transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);
        }else
        {
            scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
        }

        transform.localScale = scale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("PlayerTriggerHitbox"))
        {
            if(player.canTakeDamage)
            {
                player.TakingDamage(damage);
            }
        }

        if (other.CompareTag("Boomerang"))
        {
            if (!other.GetComponent<BoomerangAbility>().comeBack && !forth)
            {
                float random = Random.Range(0, 100);
                float boomerangDamage = other.GetComponent<BoomerangAbility>().damage;

                if (random <= player.criticalChance && player.criticalChance != 0)
                {
                    int critDamage = (int)(boomerangDamage * 1.5f);
                    TakeDamage(critDamage);
                }
                else
                {
                    TakeDamage(boomerangDamage);
                }

                forth = true;
                back = false;
            }
            if (other.GetComponent<BoomerangAbility>().comeBack && !back)
            {
                float random = Random.Range(0, 100);
                float boomerangDamage = other.GetComponent<BoomerangAbility>().damage;

                if (random <= player.criticalChance && player.criticalChance != 0)
                {
                    int critDamage = (int)(boomerangDamage * 1.5f);
                    TakeDamage(critDamage);
                }
                else
                {
                    TakeDamage(boomerangDamage);
                }

                back = true;
                forth = false;
            }
        }

        if (other.CompareTag("Obstacle"))
        {
            if(knockedBack)
            {
                TakeDamage(knockBackWallDamage);
            }
        }
    }
}
