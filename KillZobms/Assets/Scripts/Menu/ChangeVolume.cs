using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using YG;

public class ChangeVolume : MonoBehaviour
{
    private Slider slider;
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] sliderType type;

    enum sliderType { full,mus,sound}

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void Change()
    {
        switch (type)
        {
            case sliderType.full:
                audioMixer.SetFloat("Full", slider.value);
                YandexGame.savesData.fullVolume = slider.value;
                break;
            case sliderType.mus:
                audioMixer.SetFloat("Music", slider.value);
                YandexGame.savesData.musicVolume = slider.value;
                break;
            case sliderType.sound:
                audioMixer.SetFloat("Sound", slider.value);
                YandexGame.savesData.soundVolume = slider.value;
                break;
        }
        YandexGame.SaveProgress();
    }
}
