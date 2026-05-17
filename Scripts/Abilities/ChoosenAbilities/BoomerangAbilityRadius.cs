using UnityEngine;

public class BoomerangAbilityRadius : MonoBehaviour
{
    public Vector2 position;

    private float boomerangRadius = 12.0f;

    public GameObject player;

    public GameObject boomerangPointPrefab;

    public BoomerangAbilityController boomerangController;

    public bool enemyFound = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        boomerangController = GameObject.FindWithTag("BoomerangAbility").GetComponent<BoomerangAbilityController>();
    }

    private void FixedUpdate()
    {
        transform.position = player.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy") && !enemyFound)
        {
            enemyFound = true;
            boomerangController.casting = true;

            Vector2 center = player.transform.position;
            float radius = boomerangRadius;


            position = GetPointOnCircumference(center, other.transform.position, radius);
            Instantiate(boomerangPointPrefab, position, boomerangPointPrefab.transform.rotation);
        }
    }

    Vector2 GetPointOnCircumference(Vector2 center, Vector2 enemyPos, float radius)
    {
        Vector2 direction = enemyPos - center;

        Vector2 offset = direction.normalized * radius;

        return center + offset;
    }
}
