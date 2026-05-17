using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityManager : MonoBehaviour
{
    [Header("Dash")]
    public GameObject dashCooldown;
    public DashController dashController;
    public TextMeshProUGUI dashCooldownLeftText;
    public Image dashImage;

    [Header("Knockback")]
    public GameObject knockBackCooldown;
    public KnockBackAbilityController knockBackController;
    public TextMeshProUGUI knockBackCooldownLeftText;
    public Image knockBackImage;

    [Header("Black Hole")]
    public GameObject blackHoleCooldown;
    public BlackHoleAbilityController blackHoleController;
    public TextMeshProUGUI blackHoleCooldownLeftText;
    public Image blackHoleImage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dashController = gameObject.GetComponent<DashController>();
        knockBackController = gameObject.GetComponent<KnockBackAbilityController>();
        blackHoleController = gameObject.GetComponent<BlackHoleAbilityController>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAbilityOneText();
        UpdateAbilityTwoText();
        UpdateAbilityThreeText();
    }

    public void UpdateAbilityOneText()
    {
        if (!dashController.canDash)
        {
            dashCooldown.SetActive(true);
            dashImage.color = new Color32(120, 120, 120, 64);
            dashCooldownLeftText.text = $"{dashController.dashCooldownLeft}";
        }
        else
        {
            dashCooldown.SetActive(false);
            dashImage.color = new Color32(255, 255, 255, 255);
        }

    }

    public void UpdateAbilityTwoText()
    {
        if (!knockBackController.canKnockBack)
        {
            knockBackCooldown.SetActive(true);
            knockBackImage.color = new Color32(120, 120, 120, 64);
            knockBackCooldownLeftText.text = $"{knockBackController.knockBackCooldownLeft}";
        }
        else
        {
            knockBackCooldown.SetActive(false);
            knockBackImage.color = new Color32(255, 255, 255, 255);
        }

    }

    public void UpdateAbilityThreeText()
    {
        if (!blackHoleController.canUseBlackHole)
        {
            blackHoleCooldown.SetActive(true);
            blackHoleImage.color = new Color32(120, 120, 120, 64);
            blackHoleCooldownLeftText.text = $"{blackHoleController.blackHoleCooldownLeft}";
        }
        else
        {
            blackHoleCooldown.SetActive(false);
            blackHoleImage.color = new Color32(255, 255, 255, 255);
        }

    }
}
