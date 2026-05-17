using UnityEngine;

public class OrbitalAbilityController : MonoBehaviour
{
    public GameObject orbitalAbilityOrbPrefab;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        Instantiate(orbitalAbilityOrbPrefab, player.transform.position, orbitalAbilityOrbPrefab.transform.rotation);
    }
}