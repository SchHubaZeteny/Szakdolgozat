using UnityEngine;

public class ChainLightningController : MonoBehaviour
{
    private CircleCollider2D coll;

    public GameObject chainLightningEffect;

    public GameObject beenStruck;

    public PlayerController player;

    public int amountToChain;

    private GameObject startObject;

    private GameObject endObject;

    private Animator ani;

    public ParticleSystem parti;

    private int singleSpawns;

    private float damage = 15.0f;

    public AudioClip electricSound;


    void Start()
    {
        if(amountToChain == 0)
        {
            Destroy(gameObject);
        }

        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        coll = GetComponent<CircleCollider2D>();

        ani = GetComponent<Animator>();

        startObject = gameObject;

        singleSpawns = 1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !other.GetComponentInChildren<EnemyStruck>())
        {

            if (singleSpawns != 0)
            {
                endObject = other.gameObject;

                amountToChain -= 1;

                Instantiate(chainLightningEffect, other.gameObject.transform.position, Quaternion.identity);

                Instantiate(beenStruck, other.gameObject.transform);

                EnemyStatController enemy = other.GetComponent<EnemyStatController>();

                float random = Random.Range(0, 100);

                if (random <= player.criticalChance && player.criticalChance != 0)
                {
                    int critDamage = (int)(damage * 1.5f);
                    enemy.TakeDamage(critDamage);
                }
                else
                {
                    enemy.TakeDamage(damage);
                }

                ani.StopPlayback();

                coll.enabled = false;

                singleSpawns--;

                parti.Play();

                var emitParams = new ParticleSystem.EmitParams();

                emitParams.position = startObject.transform.position;

                parti.Emit(emitParams, 1);

                emitParams.position = endObject.transform.position;

                parti.Emit(emitParams, 1);

                SoundFXManager.instance.PlaySoundFXClip(electricSound, 1.3f, 0.4f, transform, 1f);

                Destroy(gameObject, 0.2f);
            }
        }
        
    }

}
