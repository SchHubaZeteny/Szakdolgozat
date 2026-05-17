using UnityEngine;

public class BlackHoleRadiusController : MonoBehaviour
{
    public AudioClip audioOne;
    public AudioClip audioTwo;
    public AudioClip audioThree;

    public PlayerController player;

    private float damage = 5f;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        SoundFXManager.instance.PlaySoundFXClip(audioOne, 0f, 5f, transform, 1f);
        SoundFXManager.instance.PlaySoundFXClip(audioTwo, 0f, 5f, transform, 1f);
        SoundFXManager.instance.PlaySoundFXClip(audioThree, 0f, 5f, transform, 1f);
        Destroy(gameObject.transform.parent.gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyStatController enemy = other.GetComponent<EnemyStatController>();
            enemy.currentBlackHole = gameObject.transform.parent.gameObject;

            float random = Random.Range(0, 100);

            if (random <= player.criticalChance && player.criticalChance != 0)
            {
                int critDamage = (int)(damage * 1.5f);
                enemy.InBlackHole(critDamage);
            }
            else
            {
                enemy.InBlackHole(damage);
            }

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && other.GetComponent<EnemyStatController>().currentBlackHole == gameObject.transform.parent.gameObject)
        {
            EnemyStatController enemy = other.GetComponent<EnemyStatController>();
            enemy.currentBlackHole = null;
        }
    }
}
