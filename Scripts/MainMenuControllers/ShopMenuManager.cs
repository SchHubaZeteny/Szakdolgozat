using System.Collections;
using TMPro;
using UnityEngine;

public class ShopMenuManager : MonoBehaviour
{
    public GameObject ScrollableStatsList;
    public GameObject ScrollableTonicsList;

    public TextMeshProUGUI moneyText;

    public GameObject notEnoughGoldPanel;
    public GameObject tonicQuantityWarningPanel;

    private float notEnoughGoldCloseCooldown = 1f;
    private float tonicQuantityWarningCloseCooldown = 1f;

    [Header("Hp Upgrade")]
    public TextMeshProUGUI levelHpText;
    public TextMeshProUGUI costHpText;
    public TextMeshProUGUI nextLevelHpValueText;
    [Header("Damage Upgrade")]
    public TextMeshProUGUI levelDamageText;
    public TextMeshProUGUI costDamageText;
    public TextMeshProUGUI nextLevelDamageValueText;
    [Header("Attack Speed Upgrade")]
    public TextMeshProUGUI levelAttackSpeedText;
    public TextMeshProUGUI costAttackSpeedText;
    public TextMeshProUGUI nextLevelAttackSpeedValueText;
    [Header("Speed Upgrade")]
    public TextMeshProUGUI levelSpeedText;
    public TextMeshProUGUI costSpeedText;
    public TextMeshProUGUI nextLevelSpeedValueText;
    [Header("Xp Upgrade")]
    public TextMeshProUGUI levelXpText;
    public TextMeshProUGUI costXpText;
    public TextMeshProUGUI nextLevelXpValueText;
    [Header("Gold Upgrade")]
    public TextMeshProUGUI levelGoldText;
    public TextMeshProUGUI costGoldText;
    public TextMeshProUGUI nextLevelGoldValueText;
    [Header("Crit Upgrade")]
    public TextMeshProUGUI levelCritText;
    public TextMeshProUGUI costCritText;
    public TextMeshProUGUI nextLevelCritValueText;
    [Header("Cdr Upgrade")]
    public TextMeshProUGUI levelCdrText;
    public TextMeshProUGUI costCdrText;
    public TextMeshProUGUI nextLevelCdrValueText;

    [Header("Lifesteal Tonic")]
    public TextMeshProUGUI lifestealTonicQuantityText;
    public TextMeshProUGUI lifestealTonicPriceText;
    [Header("Explode Tonic")]
    public TextMeshProUGUI explodeTonicQuantityText;
    public TextMeshProUGUI explodeTonicPriceText;
    [Header("Gold Heal Tonic")]
    public TextMeshProUGUI goldHealTonicQuantityText;
    public TextMeshProUGUI goldHealTonicPriceText;
    [Header("Gold Drop Tonic")]
    public TextMeshProUGUI goldDropTonicQuantityText;
    public TextMeshProUGUI goldDropTonicPriceText;

    [Header("Square Images")]
    public GameObject[] hpLevelSquares;
    public GameObject[] damageLevelSquares;
    public GameObject[] attackSpeedLevelSquares;
    public GameObject[] speedLevelSquares;
    public GameObject[] xpLevelSquares;
    public GameObject[] goldLevelSquares;
    public GameObject[] critLevelSquares;
    public GameObject[] cdrLevelSquares;

    [Header("Levels")]
    public int[] hpLevels = { 150, 200, 250, 350, 500};
    public int[] hpLevelsCost = { 200, 400, 800, 1200, 1500};
    public int[] damageLevels = { 10, 20, 25, 35, 50 };
    public int[] damageLevelsCost = { 200, 400, 800, 1200, 2000 };
    public float[] attackSpeedLevels = { 1.5f, 1.25f, 1.0f, 0.75f, 0.5f };
    public int[] attackSpeedLevelsCost = { 200, 600, 1000, 1200, 4000 };
    public float[] speedLevels = { 6.0f, 7.0f, 8.0f, 9.0f, 10.0f };
    public int[] speedLevelsCost = { 500, 600, 1000, 1200, 2300 };
    public float[] xpLevels = { 1.2f, 1.3f, 1.7f, 1.8f, 2.0f };
    public int[] xpLevelsCost = { 500, 600, 1500, 3000, 4000 };
    public float[] goldLevels = { 1.2f, 1.3f, 1.7f, 1.8f, 2.0f };
    public int[] goldLevelsCost = { 500, 600, 1500, 3000, 4000 };
    public float[] critLevels = { 10.0f, 15.0f, 20.0f, 30.0f, 50.0f };
    public int[] critLevelsCost = { 1000, 1500, 1500, 3000, 5000 };
    public float[] cdrLevels = { 10.0f, 15.0f, 20.0f, 35.0f, 50.0f };
    public int[] cdrLevelsCost = { 1000, 1500, 1500, 3000, 7000 };

    [Header("Tonic Prices")]
    private int lifestealTonicPrice = 100;
    private int lifestealTonicQuantity = 1;
    private int explodeTonicPrice = 100;
    private int explodeTonicQuantity = 1;
    private int goldHealTonicPrice = 50;
    private int goldHealTonicQuantity = 1;
    private int goldDropTonicPrice = 150;
    private int goldDropTonicQuantity = 1;


    void Update()
    {
        UpdateMoneyText();

        UpdateHpLevelText();
        UpdateHpLevelSquare();
        UpdateDamageLevelText();
        UpdateDamageLevelSquare();
        UpdateAttackSpeedLevelText();
        UpdateAttackSpeedLevelSquare();
        UpdateSpeedLevelText();
        UpdateSpeedLevelSquare();
        UpdateXpLevelText();
        UpdateXpLevelSquare();
        UpdateGoldLevelText();
        UpdateGoldLevelSquare();
        UpdateCritLevelText();
        UpdateCritLevelSquare();
        UpdateCdrLevelText();
        UpdateCdrLevelSquare();

        UpdateLifestealTonicText();
        UpdateExplodeTonicText();
        UpdateGoldHealTonicText();
        UpdateGoldDropTonicText();
    }

    public void UpdateMoneyText()
    {
        moneyText.text = "Gold: " + MainManager.Instance.playerGold;
    }

    public void OpenStatsList()
    {
        ScrollableStatsList.SetActive(true);
        ScrollableTonicsList.SetActive(false);
    }

    public void OpenTonicsList()
    {
        ScrollableTonicsList.SetActive(true);
        ScrollableStatsList.SetActive(false);
    }

    public IEnumerator NotEnoughGoldCloseCooldown()
    {
        yield return new WaitForSeconds(notEnoughGoldCloseCooldown);
        notEnoughGoldPanel.SetActive(false);
    }

    public IEnumerator TonicQuantityWarningCloseCooldown()
    {
        yield return new WaitForSeconds(tonicQuantityWarningCloseCooldown);
        tonicQuantityWarningPanel.SetActive(false);
    }

    #region Health level update
    public void UpgradeHealthLevel()
    {
        if(MainManager.Instance.hpLevel != hpLevels.Length)
        {
            if (MainManager.Instance.playerGold >= hpLevelsCost[MainManager.Instance.hpLevel])
            {
                MainManager.Instance.playerGold -= hpLevelsCost[MainManager.Instance.hpLevel];
                MainManager.Instance.playerMaxHealth = hpLevels[MainManager.Instance.hpLevel];
                MainManager.Instance.hpLevel += 1;
                MainManager.Instance.SaveProgress();
            }else
            {
                notEnoughGoldPanel.SetActive(true);
                StartCoroutine(NotEnoughGoldCloseCooldown());
            }
        }
    }


    public void UpdateHpLevelText()
    {
        if(MainManager.Instance.hpLevel != hpLevels.Length)
        {
            levelHpText.text = "Level: " + (MainManager.Instance.hpLevel + 1);
            nextLevelHpValueText.text = "Upgrade to: " + hpLevels[MainManager.Instance.hpLevel];
            costHpText.text = "Cost: " + hpLevelsCost[MainManager.Instance.hpLevel];
        } else
        {
            levelHpText.text = "Max level";
            nextLevelHpValueText.text = "";
            costHpText.text = "";
        }
        
    }


    public void UpdateHpLevelSquare()
    {
        for (int i = 0; i < MainManager.Instance.hpLevel; i++)
        {
            hpLevelSquares[i].SetActive(true);
        }
    }
    #endregion

    #region Damage level update
    public void UpgradeDamageLevel()
    {
        if (MainManager.Instance.dmgLevel != damageLevels.Length)
        {
            if (MainManager.Instance.playerGold >= damageLevelsCost[MainManager.Instance.dmgLevel])
            {
                MainManager.Instance.playerGold -= damageLevelsCost[MainManager.Instance.dmgLevel];
                MainManager.Instance.playerDamage = damageLevels[MainManager.Instance.dmgLevel];
                MainManager.Instance.dmgLevel += 1;
                MainManager.Instance.SaveProgress();
            }
            else
            {
                notEnoughGoldPanel.SetActive(true);
                StartCoroutine(NotEnoughGoldCloseCooldown());
            }
        }
    }

    public void UpdateDamageLevelText()
    {
        if (MainManager.Instance.dmgLevel != damageLevels.Length)
        {
            levelDamageText.text = "Level: " + (MainManager.Instance.dmgLevel + 1);
            nextLevelDamageValueText.text = "Upgrade to: " + damageLevels[MainManager.Instance.dmgLevel];
            costDamageText.text = "Cost: " + damageLevelsCost[MainManager.Instance.dmgLevel];
        }
        else
        {
            levelDamageText.text = "Max level";
            nextLevelDamageValueText.text = "";
            costDamageText.text = "";
        }

    }

    public void UpdateDamageLevelSquare()
    {
        for (int i = 0; i < MainManager.Instance.dmgLevel; i++)
        {
            damageLevelSquares[i].SetActive(true);
        }
    }
    #endregion

    #region Attack Speed level update
    public void UpgradeAttackSpeedLevel()
    {
        if (MainManager.Instance.asLevel != attackSpeedLevels.Length)
        {
            if (MainManager.Instance.playerGold >= attackSpeedLevelsCost[MainManager.Instance.asLevel])
            {
                MainManager.Instance.playerGold -= attackSpeedLevelsCost[MainManager.Instance.asLevel];
                MainManager.Instance.playerAttackSpeed = attackSpeedLevels[MainManager.Instance.asLevel];
                MainManager.Instance.asLevel += 1;
                MainManager.Instance.SaveProgress();
            }
            else
            {
                notEnoughGoldPanel.SetActive(true);
                StartCoroutine(NotEnoughGoldCloseCooldown());
            }
        }
    }

    public void UpdateAttackSpeedLevelText()
    {
        if (MainManager.Instance.asLevel != attackSpeedLevels.Length)
        {
            levelAttackSpeedText.text = "Level: " + (MainManager.Instance.asLevel + 1);
            nextLevelAttackSpeedValueText.text = "Upgrade to: " + attackSpeedLevels[MainManager.Instance.asLevel];
            costAttackSpeedText.text = "Cost: " + attackSpeedLevelsCost[MainManager.Instance.asLevel];
        }
        else
        {
            levelAttackSpeedText.text = "Max level";
            nextLevelAttackSpeedValueText.text = "";
            costAttackSpeedText.text = "";
        }

    }

    public void UpdateAttackSpeedLevelSquare()
    {
        for (int i = 0; i < MainManager.Instance.asLevel; i++)
        {
            attackSpeedLevelSquares[i].SetActive(true);
        }
    }
    #endregion

    #region Speed level update
    public void UpgradeSpeedLevel()
    {
        if (MainManager.Instance.speedLevel != speedLevels.Length)
        {
            if (MainManager.Instance.playerGold >= speedLevelsCost[MainManager.Instance.speedLevel])
            {
                MainManager.Instance.playerGold -= speedLevelsCost[MainManager.Instance.speedLevel];
                MainManager.Instance.playerSpeed = speedLevels[MainManager.Instance.speedLevel];
                MainManager.Instance.speedLevel += 1;
                MainManager.Instance.SaveProgress();
            }
            else
            {
                notEnoughGoldPanel.SetActive(true);
                StartCoroutine(NotEnoughGoldCloseCooldown());
            }
        }
    }

    public void UpdateSpeedLevelText()
    {
        if (MainManager.Instance.speedLevel != speedLevels.Length)
        {
            levelSpeedText.text = "Level: " + (MainManager.Instance.speedLevel + 1);
            nextLevelSpeedValueText.text = "Upgrade to: " + speedLevels[MainManager.Instance.speedLevel];
            costSpeedText.text = "Cost: " + speedLevelsCost[MainManager.Instance.speedLevel];
        }
        else
        {
            levelSpeedText.text = "Max level";
            nextLevelSpeedValueText.text = "";
            costSpeedText.text = "";
        }

    }

    public void UpdateSpeedLevelSquare()
    {
        for (int i = 0; i < MainManager.Instance.speedLevel; i++)
        {
            speedLevelSquares[i].SetActive(true);
        }
    }
    #endregion

    # region Xp level update
    public void UpgradeXpLevel()
    {
        if (MainManager.Instance.xpLevel != xpLevels.Length)
        {
            if (MainManager.Instance.playerGold >= xpLevelsCost[MainManager.Instance.xpLevel])
            {
                MainManager.Instance.playerGold -= xpLevelsCost[MainManager.Instance.xpLevel];
                MainManager.Instance.playerXp = xpLevels[MainManager.Instance.xpLevel];
                MainManager.Instance.xpLevel += 1;
                MainManager.Instance.SaveProgress();
            }
            else
            {
                notEnoughGoldPanel.SetActive(true);
                StartCoroutine(NotEnoughGoldCloseCooldown());
            }
        }
    }

    public void UpdateXpLevelText()
    {
        if (MainManager.Instance.xpLevel != xpLevels.Length)
        {
            levelXpText.text = "Level: " + (MainManager.Instance.xpLevel + 1);
            nextLevelXpValueText.text = "Upgrade to: " + xpLevels[MainManager.Instance.xpLevel];
            costXpText.text = "Cost: " + xpLevelsCost[MainManager.Instance.xpLevel];
        }
        else
        {
            levelXpText.text = "Max level";
            nextLevelXpValueText.text = "";
            costXpText.text = "";
        }

    }

    public void UpdateXpLevelSquare()
    {
        for (int i = 0; i < MainManager.Instance.xpLevel; i++)
        {
            xpLevelSquares[i].SetActive(true);
        }
    }
    #endregion

    #region Gold level update
    public void UpgradeGoldLevel()
    {
        if (MainManager.Instance.goldLevel != goldLevels.Length)
        {
            if (MainManager.Instance.playerGold >= goldLevelsCost[MainManager.Instance.goldLevel])
            {
                MainManager.Instance.playerGold -= goldLevelsCost[MainManager.Instance.goldLevel];
                MainManager.Instance.playerGoldM = goldLevels[MainManager.Instance.goldLevel];
                MainManager.Instance.goldLevel += 1;
                MainManager.Instance.SaveProgress();
            }
            else
            {
                notEnoughGoldPanel.SetActive(true);
                StartCoroutine(NotEnoughGoldCloseCooldown());
            }
        }
    }

    public void UpdateGoldLevelText()
    {
        if (MainManager.Instance.goldLevel != goldLevels.Length)
        {
            levelGoldText.text = "Level: " + (MainManager.Instance.goldLevel + 1);
            nextLevelGoldValueText.text = "Upgrade to: " + goldLevels[MainManager.Instance.goldLevel];
            costGoldText.text = "Cost: " + goldLevelsCost[MainManager.Instance.goldLevel];
        }
        else
        {
            levelGoldText.text = "Max level";
            nextLevelGoldValueText.text = "";
            costGoldText.text = "";
        }

    }

    public void UpdateGoldLevelSquare()
    {
        for (int i = 0; i < MainManager.Instance.goldLevel; i++)
        {
            goldLevelSquares[i].SetActive(true);
        }
    }
    #endregion

    #region Crit level update
    public void UpgradeCritLevel()
    {
        if (MainManager.Instance.critLevel != critLevels.Length)
        {
            if (MainManager.Instance.playerGold >= critLevelsCost[MainManager.Instance.critLevel])
            {
                MainManager.Instance.playerGold -= critLevelsCost[MainManager.Instance.critLevel];
                MainManager.Instance.playerCrit = critLevels[MainManager.Instance.critLevel];
                MainManager.Instance.critLevel += 1;
                MainManager.Instance.SaveProgress();
            }
            else
            {
                notEnoughGoldPanel.SetActive(true);
                StartCoroutine(NotEnoughGoldCloseCooldown());
            }
        }
    }

    public void UpdateCritLevelText()
    {
        if (MainManager.Instance.critLevel != critLevels.Length)
        {
            levelCritText.text = "Level: " + (MainManager.Instance.critLevel + 1);
            nextLevelCritValueText.text = "Upgrade to: " + critLevels[MainManager.Instance.critLevel];
            costCritText.text = "Cost: " + critLevelsCost[MainManager.Instance.critLevel];
        }
        else
        {
            levelCritText.text = "Max level";
            nextLevelCritValueText.text = "";
            costCritText.text = "";
        }

    }

    public void UpdateCritLevelSquare()
    {
        for (int i = 0; i < MainManager.Instance.critLevel; i++)
        {
            critLevelSquares[i].SetActive(true);
        }
    }
    #endregion

    #region Cdr level update
    public void UpgradeCdrLevel()
    {
        if (MainManager.Instance.cdrLevel != cdrLevels.Length)
        {
            if (MainManager.Instance.playerGold >= cdrLevelsCost[MainManager.Instance.cdrLevel])
            {
                MainManager.Instance.playerGold -= cdrLevelsCost[MainManager.Instance.cdrLevel];
                MainManager.Instance.playerCdr = cdrLevels[MainManager.Instance.cdrLevel];
                MainManager.Instance.cdrLevel += 1;
                MainManager.Instance.SaveProgress();
            }
            else
            {
                notEnoughGoldPanel.SetActive(true);
                StartCoroutine(NotEnoughGoldCloseCooldown());
            }
        }
    }

    public void UpdateCdrLevelText()
    {
        if (MainManager.Instance.cdrLevel != cdrLevels.Length)
        {
            levelCdrText.text = "Level: " + (MainManager.Instance.cdrLevel + 1);
            nextLevelCdrValueText.text = "Upgrade to: " + critLevels[MainManager.Instance.cdrLevel];
            costCdrText.text = "Cost: " + cdrLevelsCost[MainManager.Instance.cdrLevel];
        }
        else
        {
            levelCdrText.text = "Max level";
            nextLevelCdrValueText.text = "";
            costCdrText.text = "";
        }

    }

    public void UpdateCdrLevelSquare()
    {
        for (int i = 0; i < MainManager.Instance.cdrLevel; i++)
        {
            cdrLevelSquares[i].SetActive(true);
        }
    }
    #endregion



    #region Lifesteal Tonic
    public void BuyLifestealTonic()
    {
        if (MainManager.Instance.playerGold >= lifestealTonicPrice * lifestealTonicQuantity)
        {
            if (MainManager.Instance.lifestealTonicQuantity + lifestealTonicQuantity > 5)
            {
                tonicQuantityWarningPanel.SetActive(true);
                StartCoroutine(TonicQuantityWarningCloseCooldown());
            }
            else
            {
                MainManager.Instance.playerGold -= lifestealTonicPrice * lifestealTonicQuantity;
                MainManager.Instance.lifestealTonicQuantity += lifestealTonicQuantity;
                MainManager.Instance.SaveProgress();
            }
        }
        else
        {
            notEnoughGoldPanel.SetActive(true);
            StartCoroutine(NotEnoughGoldCloseCooldown());
        }
    }

    public void UpdateLifestealTonicText()
    {
        lifestealTonicQuantityText.text = $"{lifestealTonicQuantity}";
        lifestealTonicPriceText.text = $"Price: {lifestealTonicPrice * lifestealTonicQuantity}";

    }

    public void AddingQuantityToLifestealTonic()
    {
        if(lifestealTonicQuantity + 1 <= 5)
        {
            lifestealTonicQuantity++;
        }
    }

    public void SubstractQuantityFromLifestealTonic()
    {
        if (lifestealTonicQuantity - 1 >= 1)
        {
            lifestealTonicQuantity--;
        }
    }

    #endregion

    #region Explode Tonic
    public void BuyExplodeTonic()
    {
        if (MainManager.Instance.playerGold >= explodeTonicPrice * explodeTonicQuantity)
        {
            if (MainManager.Instance.explodeTonicQuantity + explodeTonicQuantity > 5)
            {
                tonicQuantityWarningPanel.SetActive(true);
                StartCoroutine(TonicQuantityWarningCloseCooldown());
            }
            else
            {
                MainManager.Instance.playerGold -= explodeTonicPrice * explodeTonicQuantity;
                MainManager.Instance.explodeTonicQuantity += explodeTonicQuantity;
                MainManager.Instance.SaveProgress();
            }
        }
        else
        {
            notEnoughGoldPanel.SetActive(true);
            StartCoroutine(NotEnoughGoldCloseCooldown());
        }
    }

    public void UpdateExplodeTonicText()
    {
        explodeTonicQuantityText.text = $"{explodeTonicQuantity}";
        explodeTonicPriceText.text = $"price: {explodeTonicPrice * explodeTonicQuantity}";

    }

    public void AddingQuantityToExplodeTonic()
    {
        if (explodeTonicQuantity + 1 <= 5)
        {
            explodeTonicQuantity++;
        }
    }

    public void SubstractQuantityFromExplodeTonic()
    {
        if (explodeTonicQuantity - 1 >= 1)
        {
            explodeTonicQuantity--;
        }
    }

    #endregion

    #region Gold Heal Tonic
    public void BuyGoldHealTonic()
    {
        if (MainManager.Instance.playerGold >= goldHealTonicPrice * goldHealTonicQuantity)
        {
            if (MainManager.Instance.goldHealTonicQuantity + goldHealTonicQuantity > 5)
            {
                tonicQuantityWarningPanel.SetActive(true);
                StartCoroutine(TonicQuantityWarningCloseCooldown());
            }
            else
            {
                MainManager.Instance.playerGold -= goldHealTonicPrice * goldHealTonicQuantity;
                MainManager.Instance.goldHealTonicQuantity += goldHealTonicQuantity;
                MainManager.Instance.SaveProgress();
            }
        }
        else
        {
            notEnoughGoldPanel.SetActive(true);
            StartCoroutine(NotEnoughGoldCloseCooldown());
        }
    }

    public void UpdateGoldHealTonicText()
    {
        goldHealTonicQuantityText.text = $"{goldHealTonicQuantity}";
        goldHealTonicPriceText.text = $"price: {goldHealTonicPrice * goldHealTonicQuantity}";

    }

    public void AddingQuantityToGoldHealTonic()
    {
        if (goldHealTonicQuantity + 1 <= 5)
        {
            goldHealTonicQuantity++;
        }
    }

    public void SubstractQuantityFromGoldHealTonic()
    {
        if (goldHealTonicQuantity - 1 >= 1)
        {
            goldHealTonicQuantity--;
        }
    }

    #endregion

    #region Gold Drop Tonic
    public void BuyGoldDropTonic()
    {
        if (MainManager.Instance.playerGold >= goldDropTonicPrice * goldDropTonicQuantity)
        {
            if (MainManager.Instance.goldDropTonicQuantity + goldDropTonicQuantity > 5)
            {
                tonicQuantityWarningPanel.SetActive(true);
                StartCoroutine(TonicQuantityWarningCloseCooldown());
            }
            else
            {
                MainManager.Instance.playerGold -= goldDropTonicPrice * goldDropTonicQuantity;
                MainManager.Instance.goldDropTonicQuantity += goldDropTonicQuantity;
                MainManager.Instance.SaveProgress();
            }
        }
        else
        {
            notEnoughGoldPanel.SetActive(true);
            StartCoroutine(NotEnoughGoldCloseCooldown());
        }
    }

    public void UpdateGoldDropTonicText()
    {
        goldDropTonicQuantityText.text = $"{goldDropTonicQuantity}";
        goldDropTonicPriceText.text = $"price: {goldDropTonicPrice * goldDropTonicQuantity}";

    }

    public void AddingQuantityToGoldDropTonic()
    {
        if (goldDropTonicQuantity + 1 <= 5)
        {
            goldDropTonicQuantity++;
        }
    }

    public void SubstractQuantityFromGoldDropTonic()
    {
        if (goldDropTonicQuantity - 1 >= 1)
        {
            goldDropTonicQuantity--;
        }
    }

    #endregion
}
