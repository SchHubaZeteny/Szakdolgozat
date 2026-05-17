using System.Collections;
using UnityEngine;

public class SummoningEnemyController : MonoBehaviour
{
    private float summoningCooldown = 15.0f;
    private float coordinate = 1.5f;
    public GameObject enemyPrefab;


    void Start()
    {
        SummonEnemies();
    }

    public void SummonEnemies()
    {
        float randomPosXOne = Random.Range(-coordinate, coordinate);
        float randomPosYOne = Random.Range(-coordinate, coordinate);
        Vector2 randomPosOne = new Vector2(randomPosXOne, randomPosYOne);

        float randomPosXTwo = Random.Range(-coordinate, coordinate);
        float randomPosYTwo = Random.Range(-coordinate, coordinate);
        Vector2 randomPosTwo = new Vector2(randomPosXTwo, randomPosYTwo);

        float randomPosXThree = Random.Range(-coordinate, coordinate);
        float randomPosYThree = Random.Range(-coordinate, coordinate);
        Vector2 randomPosThree = new Vector2(randomPosXThree, randomPosYThree);

        Instantiate(enemyPrefab, (Vector2)transform.position + randomPosOne, enemyPrefab.transform.rotation);
        Instantiate(enemyPrefab, (Vector2)transform.position + randomPosTwo, enemyPrefab.transform.rotation);
        Instantiate(enemyPrefab, (Vector2)transform.position + randomPosThree, enemyPrefab.transform.rotation);

        StartCoroutine(SummonCooldown());
    }

    public IEnumerator SummonCooldown()
    {
        yield return new WaitForSeconds(summoningCooldown);

        SummonEnemies();
    }
}
