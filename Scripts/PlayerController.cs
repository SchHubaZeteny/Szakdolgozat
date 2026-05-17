using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxHealth = 100.0f;
    public float currentHealth;
    public float speed = 5.0f;
    public float xp = 0;
    public float xpMultiplier = 1.0f;
    public float maxGold;
    public float gold = 0;
    public float goldMultiplier = 1.0f;
    public float criticalChance = 0.0f;

    public bool canTakeDamage = true;
    public float takingDamageCooldown = 0.3f;

    public bool isDead = false;

    public bool isDashing = false;

    public bool isPortaling = false;

    public bool usingLifestealTonic = false;
    public bool usingExplodeTonic = false;
    public bool usingGoldHealTonic = false;
    public bool usingGoldDropTonic = false;

    public int[] levels = {100, 250, 500, 750, 1000};
    public int currentLevel;
    public int currentLevelXP;
    public bool maxLevel = false;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    public GameMenuManager gameMenuManager;

    private Animator animator;
    private bool flip;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        gameMenuManager = GameObject.FindWithTag("GameMenuManager").GetComponent<GameMenuManager>();

        if(MainManager.Instance != null)
        {
            maxGold = MainManager.Instance.playerGold;
            maxHealth = MainManager.Instance.playerMaxHealth == 0 ? 100.0f : MainManager.Instance.playerMaxHealth;
            speed = MainManager.Instance.playerSpeed == 0 ? 5.0f : MainManager.Instance.playerSpeed;
            xpMultiplier = MainManager.Instance.playerXp == 0 ? 1 : MainManager.Instance.playerXp;
            goldMultiplier = MainManager.Instance.playerGoldM == 0 ? 1 : MainManager.Instance.playerGoldM;
            criticalChance = MainManager.Instance.playerCrit == 0 ? 3.0f : MainManager.Instance.playerCrit;
            usingLifestealTonic = MainManager.Instance.usingLifestealTonic == true ? true : MainManager.Instance.usingLifestealTonic;
            usingExplodeTonic = MainManager.Instance.usingExplodeTonic == true ? true : MainManager.Instance.usingExplodeTonic;
            usingGoldHealTonic = MainManager.Instance.usingGoldHealTonic == true ? true : MainManager.Instance.usingGoldHealTonic;
            usingGoldDropTonic = MainManager.Instance.usingGoldDropTonic == true ? true : MainManager.Instance.usingGoldDropTonic;
        }
        if(usingLifestealTonic)
        {
            MainManager.Instance.lifestealTonicQuantity--;
            MainManager.Instance.SaveProgress();
        }
        if (usingExplodeTonic)
        {
            MainManager.Instance.explodeTonicQuantity--;
            MainManager.Instance.SaveProgress();
        }
        if (usingGoldHealTonic)
        {
            MainManager.Instance.goldHealTonicQuantity--;
            MainManager.Instance.SaveProgress();
        }
        if (usingGoldDropTonic)
        {
            MainManager.Instance.goldDropTonicQuantity--;
            MainManager.Instance.SaveProgress();
        }
        currentHealth = maxHealth;
        currentLevel = 0;
        currentLevelXP = levels[currentLevel];
    }

    private void Update()
    {
        FacingDirection();
    }

    void FixedUpdate()
    {
        MovePlayer();
        LevelUp();
    }

    public void MovePlayer()
    {
        if(!isDashing && !isPortaling)
        {
            moveInput.x = Input.GetAxisRaw("Horizontal");
            moveInput.y = Input.GetAxisRaw("Vertical");
            moveInput.Normalize();

            rb.linearVelocity = moveInput * speed;

            if(moveInput.x != 0  || moveInput.y != 0)
            {
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }
        }
    }

    public void FacingDirection()
    {
        Vector2 scale = transform.localScale;

        if (moveInput.x < 0)
        {
            scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);
        }
        else if(moveInput.x > 0)
        {
            scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
        }

        transform.localScale = scale;
    }

    public void LevelUp()
    {
        if (!maxLevel)
        {
            if (xp >= currentLevelXP)
            {
                xp = 0;
                currentLevel += 1;
                currentLevelXP = levels[currentLevel];
                gameMenuManager.EnterLevelUpMenu();
            }
            else if (currentLevel == levels.Length - 1)
            {
                maxLevel = true;
            }
        }
    }

    public void Heal(float healAmount)
    {
        if(currentHealth + healAmount > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += healAmount;
        }
    }

    public void TakingDamage(float damage)
    {
        if (isDead)
        {
            return;
        }
        if (canTakeDamage)
        {
            canTakeDamage = false;
            currentHealth -= damage;
            if (currentHealth - damage < 0)
            {
                currentHealth = 0;
            }

            if (currentHealth <= 0)
            {
                isDead = true;
                gameMenuManager.EnterLoseMenu();
            }

            StartCoroutine(TakingDamageCooldown());
        }
    }

    public IEnumerator TakingDamageCooldown()
    {
        yield return new WaitForSeconds(takingDamageCooldown);
        canTakeDamage = true;
    }
}
