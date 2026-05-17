using System.Collections;
using UnityEngine;

public class BigDamageCircleAbilityFillRadiusController : MonoBehaviour
{
    private float timer = 15f;

    public GameObject damageCirclePrefab;

    void Start()
    {
        StartCoroutine(Death());
    }

    public IEnumerator Death()
    {
        yield return new WaitForSeconds(timer);
        Instantiate(damageCirclePrefab, transform.position, damageCirclePrefab.transform.rotation);
        Destroy(gameObject);
    }
}
