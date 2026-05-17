using System.Collections;
using UnityEngine;

public class ChainLightningAbilityController : MonoBehaviour
{
    public PlayerController player;

    public bool canChainLight = true;

    public int amountToChain = 10;

    private float cooldown = 25f;


    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    public void UsingChainlightning()
    {
        StartCoroutine(ChainLightCooldown());
    }

    public IEnumerator ChainLightCooldown()
    {
        canChainLight = false;
        yield return new WaitForSeconds(cooldown);
        canChainLight = true;
    }
}
