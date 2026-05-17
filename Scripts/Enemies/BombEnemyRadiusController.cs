using UnityEngine;

public class BombEnemyRadiusController : MonoBehaviour
{
    public GameObject bombEnemy;

    void FixedUpdate()
    {
        transform.position = bombEnemy.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("PlayerTriggerHitbox"))
        {
            bombEnemy.GetComponent<BombEnemyController>().ActivateExploding();
            Destroy(gameObject);
        }
    }
}
