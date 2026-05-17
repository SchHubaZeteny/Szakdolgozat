using System.Collections;
using UnityEngine;

public class FreezeAbilityController : MonoBehaviour
{
    public PlayerController player;
    public GameObject freezeRadiusPrefab;
    public GameObject freezeRadius;

    private float cooldown = 20f;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        CastFreez();
    }

    public void CastFreez()
    {
        Instantiate(freezeRadiusPrefab, player.transform.position, freezeRadiusPrefab.transform.rotation);

        StartCoroutine(Freeze());
    }

    IEnumerator Freeze()
    {
        yield return new WaitForSeconds(cooldown);
        CastFreez();
    }

}
