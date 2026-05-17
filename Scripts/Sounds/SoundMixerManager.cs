using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManager : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetSoundFXVolume(float level)
    {
        MainManager.Instance.soundFXVolume = level;
        audioMixer.SetFloat("soundFXVolume", Mathf.Log10(MainManager.Instance.soundFXVolume) * 20f);
        MainManager.Instance.SaveProgress();
    }

    public void SetMusicVolume(float level)
    {
        MainManager.Instance.musicVolume = level;
        audioMixer.SetFloat("musicVolume", Mathf.Log10(MainManager.Instance.musicVolume) * 20f);
        MainManager.Instance.SaveProgress();
    }
}
