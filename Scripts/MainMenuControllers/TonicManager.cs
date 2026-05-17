using TMPro;
using UnityEngine;

public class TonicManager : MonoBehaviour
{
    [Header("Lifesteal Tonic")]
    public GameObject lifestealTonic;
    public GameObject lifestealTonicEquipButton;
    public GameObject lifestealTonicUnequipButton;
    public TextMeshProUGUI lifestealTonicQuantityText;
    public int lifestealTonicQuantity = 0;

    [Header("Explode Tonic")]
    public GameObject explodeTonic;
    public GameObject explodeTonicEquipButton;
    public GameObject explodeTonicUnequipButton;
    public TextMeshProUGUI explodeTonicQuantityText;
    public int explodeTonicQuantity = 0;

    [Header("Gold Heal Tonic")]
    public GameObject goldHealTonic;
    public GameObject goldHealTonicEquipButton;
    public GameObject goldHealTonicUnequipButton;
    public TextMeshProUGUI goldHealTonicQuantityText;
    public int goldHealTonicQuantity = 0;

    [Header("Gold Drop Tonic")]
    public GameObject goldDropTonic;
    public GameObject goldDropTonicEquipButton;
    public GameObject goldDropTonicUnequipButton;
    public TextMeshProUGUI goldDropTonicQuantityText;
    public int goldDropTonicQuantity = 0;


    void Start()
    {
        lifestealTonicQuantity = MainManager.Instance.lifestealTonicQuantity;
        explodeTonicQuantity = MainManager.Instance.explodeTonicQuantity;
        goldHealTonicQuantity = MainManager.Instance.goldHealTonicQuantity;
        goldDropTonicQuantity = MainManager.Instance.goldDropTonicQuantity;
    }

    void Update()
    {
        UpdateQuantities();

        UpdateLifestealTonic();
        UpdateExplodeTonic();
        UpdateGoldHealTonic();
        UpdateGoldDropTonic();
    }

    public void UpdateQuantities()
    {
        lifestealTonicQuantity = MainManager.Instance.lifestealTonicQuantity;
        explodeTonicQuantity = MainManager.Instance.explodeTonicQuantity;
        goldHealTonicQuantity = MainManager.Instance.goldHealTonicQuantity;
        goldDropTonicQuantity = MainManager.Instance.goldDropTonicQuantity;
    }

    #region LifestealTonic
    public void UpdateLifestealTonic()
    {
        if(MainManager.Instance.lifestealTonicQuantity > 0)
        {
            lifestealTonic.SetActive(true);
            lifestealTonicQuantityText.text = $"Left: {lifestealTonicQuantity}";
        }else
        {
            lifestealTonic.SetActive(false);
        }
    }

    public void EquipLifestealTonic()
    {
        lifestealTonicQuantity--;
        MainManager.Instance.usingLifestealTonic = true;
        lifestealTonicEquipButton.SetActive(false);
        lifestealTonicUnequipButton.SetActive(true);
    }

    public void UnequipLifestealTonic()
    {
        lifestealTonicQuantity++;
        MainManager.Instance.usingLifestealTonic = false;
        lifestealTonicUnequipButton.SetActive(false);
        lifestealTonicEquipButton.SetActive(true);
    }


    #endregion

    #region ExplodeTonic
    public void UpdateExplodeTonic()
    {
        if (MainManager.Instance.explodeTonicQuantity > 0)
        {
            explodeTonic.SetActive(true);
            explodeTonicQuantityText.text = $"Left: {explodeTonicQuantity}";
        }
        else
        {
            explodeTonic.SetActive(false);
        }
    }

    public void EquipExplodeTonic()
    {
        explodeTonicQuantity--;
        MainManager.Instance.usingExplodeTonic = true;
        explodeTonicEquipButton.SetActive(false);
        explodeTonicUnequipButton.SetActive(true);
    }

    public void UnequipExplodeTonic()
    {
        explodeTonicQuantity++;
        MainManager.Instance.usingExplodeTonic = false;
        explodeTonicUnequipButton.SetActive(false);
        explodeTonicEquipButton.SetActive(true);
    }


    #endregion

    #region GoldHealTonic
    public void UpdateGoldHealTonic()
    {
        if (MainManager.Instance.goldHealTonicQuantity > 0)
        {
            goldHealTonic.SetActive(true);
            goldHealTonicQuantityText.text = $"Left: {goldHealTonicQuantity}";
        }
        else
        {
            goldHealTonic.SetActive(false);
        }
    }

    public void EquipGoldHealTonic()
    {
        goldHealTonicQuantity--;
        MainManager.Instance.usingGoldHealTonic = true;
        goldHealTonicEquipButton.SetActive(false);
        goldHealTonicUnequipButton.SetActive(true);
    }

    public void UnequipGoldHealTonic()
    {
        goldHealTonicQuantity++;
        MainManager.Instance.usingGoldHealTonic = false;
        goldHealTonicUnequipButton.SetActive(false);
        goldHealTonicEquipButton.SetActive(true);
    }


    #endregion

    #region GoldDropTonic
    public void UpdateGoldDropTonic()
    {
        if (MainManager.Instance.goldDropTonicQuantity > 0)
        {
            goldDropTonic.SetActive(true);
            goldDropTonicQuantityText.text = $"Left: {goldDropTonicQuantity}";
        }
        else
        {
            goldDropTonic.SetActive(false);
        }
    }

    public void EquipGoldDropTonic()
    {
        goldDropTonicQuantity--;
        MainManager.Instance.usingGoldDropTonic = true;
        goldDropTonicEquipButton.SetActive(false);
        goldDropTonicUnequipButton.SetActive(true);
    }

    public void UnequipGoldDropTonic()
    {
        goldDropTonicQuantity++;
        MainManager.Instance.usingGoldDropTonic = false;
        goldDropTonicUnequipButton.SetActive(false);
        goldDropTonicEquipButton.SetActive(true);
    }


    #endregion
}
