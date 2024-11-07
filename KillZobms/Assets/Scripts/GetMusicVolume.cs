using UnityEngine;
using UnityEngine.Audio;
using YG;

public class GetMusicVolume : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    private void OnEnable()
    {
        YandexGame.GetDataEvent += Load;
    }

    private void OnDisable()
    {
        YandexGame.GetDataEvent -= Load;
    }

    private void Start()
    {
        if (YandexGame.SDKEnabled)
            Load();
    }

    
    private void Load()
    {
        audioMixer.SetFloat("Full",YandexGame.savesData.fullVolume);
        audioMixer.SetFloat("Sound", YandexGame.savesData.soundVolume);
        audioMixer.SetFloat("Music", YandexGame.savesData.musicVolume);
    }
}
