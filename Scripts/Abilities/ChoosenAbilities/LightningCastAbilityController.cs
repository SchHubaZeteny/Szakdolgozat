using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class LightningCastAbilityController : MonoBehaviour
{
    public PlayerController player;
    public GameObject lightningCastRadiusPrefab;
    public GameObject lightningCastDamagePrefab;

    public GameObject lightningCastDamage;

    public Vector2 enemyPos;

    private float cooldown = 20f;
    public bool onCooldown = false;


    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        Instantiate(lightningCastRadiusPrefab, player.transform.position, lightningCastRadiusPrefab.transform.rotation);
    }

    public void CastLightning()
    {
        onCooldown = true;
        lightningCastDamage = Instantiate(lightningCastDamagePrefab, player.transform.position, lightningCastDamagePrefab.transform.rotation);
        lightningCastDamage.GetComponent<LightningCastAbilityDamageController>().enemyPos = enemyPos;
        StartCoroutine(Cooldown());
    }

    public IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        onCooldown = false;
        Instantiate(lightningCastRadiusPrefab, player.transform.position, lightningCastRadiusPrefab.transform.rotation);
    }
}
