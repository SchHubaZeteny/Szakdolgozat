using System.Collections;
using UnityEngine;

public class BombAbilityGameObjectController : MonoBehaviour
{
    public GameObject bombRadiusPrefab;

    private float countdown = 5f;

    void Start()
    {
        StartCoroutine(ExplodeBomb());
    }

    IEnumerator ExplodeBomb()
    {
        yield return new WaitForSeconds(countdown);

        Instantiate(bombRadiusPrefab, transform.position, bombRadiusPrefab.transform.rotation);

        Destroy(gameObject);
    }

}
