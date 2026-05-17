using System.Collections;
using UnityEngine;

public class BigDamageCircleAbilityController : MonoBehaviour
{
    public PlayerController player;

    public GameObject fillCirclePrefab;

    private float cooldown = 120f;

    private float offset = 10f;

    private Vector2 playerPos;


    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        DeployCircle();
    }

    public void DeployCircle()
    {
        float randomPosX = Random.Range(-offset, offset);
        float randomPosY = Random.Range(-offset, offset);

        playerPos = player.transform.position;

        Vector2 pos = new Vector2(randomPosX + playerPos.x, randomPosY + playerPos.y);

        Instantiate(fillCirclePrefab, pos, fillCirclePrefab.transform.rotation);

        StartCoroutine(DeployCircleCooldown());
    }

    public IEnumerator DeployCircleCooldown()
    {
        yield return new WaitForSeconds(cooldown);

        DeployCircle();
    }
}
