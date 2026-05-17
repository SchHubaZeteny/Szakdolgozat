using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class BombEnemyController : MonoBehaviour
{
    public bool isActivated = false;
    private EnemyStatController enemyStat;

    private float timeToExplode = 5f;

    public GameObject bombRadiusPrefab;
    public GameObject bombExplosionPrefab;
    public GameObject bombRadius;

    public SpriteRenderer render;

    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        enemyStat = gameObject.GetComponent<EnemyStatController>();

        bombRadius = Instantiate(bombRadiusPrefab, transform.position, bombRadiusPrefab.transform.rotation);
        bombRadius.GetComponent<BombEnemyRadiusController>().bombEnemy = gameObject;
    }

    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(timeToExplode);
        Instantiate(bombExplosionPrefab, transform.position, bombExplosionPrefab.transform.rotation);
        Destroy(gameObject);
    }

    public void ActivateExploding()
    {
        render.color = new Color32(229, 82, 82, 255);
        enemyStat.maxSpeed = 5.0f;
        enemyStat.speed = 5.0f;
        StartCoroutine(Explosion());
    }

}
