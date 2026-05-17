using System.Collections;
using UnityEngine;

public class FireCircleAbilityController : MonoBehaviour
{
    public PlayerController player;
    public GameObject fireCircleRadiusPrefab;

    private float cooldown = 30f;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        CastFireCircle();
    }

    public void CastFireCircle()
    {
        Instantiate(fireCircleRadiusPrefab, player.transform.position, fireCircleRadiusPrefab.transform.rotation);

        StartCoroutine(CastFireCircleCooldown());
    }

    public IEnumerator CastFireCircleCooldown()
    {
        yield return new WaitForSeconds(cooldown);

        CastFireCircle();
    }
}
