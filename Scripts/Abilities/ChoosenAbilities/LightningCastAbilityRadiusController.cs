using UnityEngine;

public class LightningCastAbilityRadiusController : MonoBehaviour
{
    public GameObject player;

    public LightningCastAbilityController controller;


    void Start()
    {
        player = GameObject.FindWithTag("Player");
        controller = GameObject.FindWithTag("LightningCastAbility").GetComponent<LightningCastAbilityController>();
    }

    private void Update()
    {
        transform.position = player.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (!controller.onCooldown)
            {
                controller.enemyPos = other.transform.position;
                controller.CastLightning();
                Destroy(gameObject);
            }
        }
    }

}
