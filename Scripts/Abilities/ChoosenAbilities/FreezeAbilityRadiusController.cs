using UnityEngine;

public class FreezeAbilityRadiusController : MonoBehaviour
{
    public AudioClip freezeSound;

    void Start()
    {
        SoundFXManager.instance.PlaySoundFXClip(freezeSound, 0f, freezeSound.length, transform, 1f);

        Destroy(gameObject,0.4f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyStatController>().Frozen();
        }
    }
}
