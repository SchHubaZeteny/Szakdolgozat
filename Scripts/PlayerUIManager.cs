using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    public float healthMaximum;
    public float healthCurrent;
    public Image healthMask;

    public float xpMaximum;
    public float xpCurrent;
    public Image xpMask;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI timeLeftText;
    public TextMeshProUGUI XPText;
    public TextMeshProUGUI GoldText;
    public TextMeshProUGUI LevelText;

    public PlayerController player;
    public GameManager gameManager;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        healthMaximum = player.maxHealth;
        xpMaximum = player.levels[0];
    }

    void Update()
    {
        GetCurrentHealthFill();
        GetCurrentXpFill();

        UpdateHealthText();
        UpdateTimeLeftText();
        UpdateXPText();
        UpdateGoldText();
        UpdateLevelText();
    }

    void GetCurrentHealthFill()
    {
        healthMaximum = player.maxHealth;
        healthCurrent = player.currentHealth;
        float fillAmount = (float)healthCurrent / (float)healthMaximum;
        healthMask.fillAmount = fillAmount;
    }

    void GetCurrentXpFill()
    {
        xpMaximum = player.currentLevelXP;
        xpCurrent = player.xp;
        float fillAmount = (float)xpCurrent / (float)xpMaximum;
        xpMask.fillAmount = fillAmount;
    }

    public void UpdateHealthText()
    {
        healthText.text = player.currentHealth + "/" + player.maxHealth;
    }

    public void UpdateTimeLeftText()
    {
        int minutesLeft = gameManager.secondsLeft / 60;
        float seconds = gameManager.secondsLeft % 60;
        timeLeftText.text = $"{minutesLeft}:{seconds:00}";
    }

    public void UpdateXPText()
    {
        if (!player.maxLevel)
        {
            XPText.text = $"{player.xp}/{player.currentLevelXP}";
        }
        else
        {
            XPText.text = $"Max level";
        }

    }

    public void UpdateLevelText()
    {
        LevelText.text = $"Lvl {player.currentLevel + 1}";
    }

    public void UpdateGoldText()
    {
        GoldText.text = $"Gold: {player.gold}";
    }
}
