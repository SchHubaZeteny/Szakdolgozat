using System.Collections;
using UnityEngine;

public class BoomerangAbilityController : MonoBehaviour
{
    public GameObject radiusPrefab;

    public GameObject boomerangPrefab;

    public GameObject player;

    public GameObject boomerangRadius;

    public BoomerangAbilityRadius radius;

    public bool casting = false;

    private float castCooldown = 10f;


    void Start()
    {
        player = GameObject.FindWithTag("Player");
        Instantiate(radiusPrefab, player.transform.position, radiusPrefab.transform.rotation);
        casting = false;
        radius = GameObject.FindWithTag("BoomerangAbilityRadius").GetComponent<BoomerangAbilityRadius>();
    }


    void Update()
    {
        if (casting)
        {
            casting = false;
            radius = GameObject.FindWithTag("BoomerangAbilityRadius").GetComponent<BoomerangAbilityRadius>();
            CastBoomerang();
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(castCooldown);
        Instantiate(radiusPrefab, player.transform.position, radiusPrefab.transform.rotation);
    }

    public void CastBoomerang()
    {
        boomerangRadius = GameObject.FindWithTag("BoomerangAbilityRadius");
        Instantiate(boomerangPrefab, player.transform.position, boomerangPrefab.transform.rotation);
        Destroy(boomerangRadius);
        StartCoroutine(Cooldown());
    }
}
