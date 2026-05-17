using System.Collections;
using UnityEngine;

public class KnockBackAbilityController : MonoBehaviour
{
    public GameObject knockBackRadiusPrefab;

    public PlayerController player;

    public bool canKnockBack;

    private float knockBackCooldown = 45f;
    public float knockBackCooldownLeft;

    private float coolDownReduction;


    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        if (MainManager.Instance != null)
        {
            coolDownReduction = MainManager.Instance.playerCdr == 0 ? 0.0f : MainManager.Instance.playerCdr;

            if (coolDownReduction != 0)
            {
                knockBackCooldown = (int)(knockBackCooldown * (coolDownReduction / 100.0f));
            }
        }

        canKnockBack = true;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2) && canKnockBack)
        {
            MainManager.Instance.useKnockbackQuestProgress++;
            canKnockBack = false;
            KnockBack();
            knockBackCooldownLeft = knockBackCooldown;
}
    }

    public void KnockBack()
    {
        Instantiate(knockBackRadiusPrefab, player.transform.position, knockBackRadiusPrefab.transform.rotation);

        StartCoroutine(Cooldown());
        StartCoroutine(SecondsLeft());
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(knockBackCooldown);
        canKnockBack = true;
    }

    private IEnumerator SecondsLeft()
    {
        while (!canKnockBack)
        {
            yield return new WaitForSeconds(1);
            knockBackCooldownLeft -= 1;
        }
    }
}
