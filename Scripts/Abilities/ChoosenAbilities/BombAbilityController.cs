using System.Collections;
using UnityEngine;

public class BombAbilityController : MonoBehaviour
{
    public PlayerController player;
    public GameObject bombPrefab;

    private float cooldown = 20f;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        DeployBomb();
    }

    public void DeployBomb()
    {
        Instantiate(bombPrefab, player.transform.position, bombPrefab.transform.rotation);

        StartCoroutine(BombCooldown());
    }

    IEnumerator BombCooldown()
    {
        yield return new WaitForSeconds(cooldown);
        DeployBomb();
    }

}
