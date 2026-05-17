using System.Collections;
using UnityEngine;

public class GameMusicManager : MonoBehaviour
{
    public AudioClip[] audioClip;

    private AudioClip choosenAudio;


    void Start()
    {
        int rand = Random.Range(0, audioClip.Length);

        choosenAudio = audioClip[rand];

        SoundFXManager.instance.PlayRandomMusicClip(choosenAudio, transform, 1f);

        StartCoroutine(LoopMusicCooldown());
    }

    public void LoopMusic()
    {
        int rand = Random.Range(0, audioClip.Length);

        choosenAudio = audioClip[rand];

        SoundFXManager.instance.PlayRandomMusicClip(choosenAudio, transform, 1f);

        StartCoroutine(LoopMusicCooldown());
        
    }

    public IEnumerator LoopMusicCooldown()
    {
        yield return new WaitForSeconds(choosenAudio.length);
        LoopMusic();
    }
}
