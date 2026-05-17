using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    public Slider soundFXSlider;
    public Slider musicSlider;

    void Start()
    {
        if(MainManager.Instance.soundFXVolume != 0)
        {
            soundFXSlider.value = MainManager.Instance.soundFXVolume;
        }
        if(MainManager.Instance.musicVolume != 0)
        {
            musicSlider.value = MainManager.Instance.musicVolume;
        }
    }
}
