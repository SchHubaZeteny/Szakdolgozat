using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public int goldValue = 5;

    public int xpValue = 5;

    public int goldHeal = 3;

    public bool isGold;
    public bool isXp;
    public bool isHeal;

    public AudioClip goldAudio;
    public AudioClip xpAudio;
    public AudioClip healAudio;

    public PlayerController player;


    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerPickUpHitbox"))
        {
            if (isGold)
            {
                player.gold += (int)(goldValue * player.goldMultiplier);
                if (player.usingGoldHealTonic)
                {
                    player.Heal(goldHeal);
                }

                SoundFXManager.instance.PlaySoundFXClip(goldAudio, 0f, goldAudio.length, transform, 1f);

                Destroy(gameObject);
            }

            if (isXp)
            {
                if (!player.maxLevel)
                {
                    player.xp += (int)(xpValue * player.xpMultiplier);
                }

                SoundFXManager.instance.PlaySoundFXClip(xpAudio, 0f, xpAudio.length, transform, 1f);

                Destroy(gameObject);
            }

            if(isHeal)
            {
                if(player.currentHealth != player.maxHealth)
                {
                    int healing = (int)(player.maxHealth * 0.2f);
                    player.Heal(healing);

                    SoundFXManager.instance.PlaySoundFXClip(healAudio, 0f, healAudio.length, transform, 1f);
                }

                Destroy(gameObject);
            }
        }
    }
}
