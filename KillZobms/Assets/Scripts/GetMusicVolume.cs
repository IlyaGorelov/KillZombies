using UnityEngine;
using UnityEngine.Audio;
using YG;

public class GetMusicVolume : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] FirstPersonController firstPersonController;

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
        firstPersonController.mouseSensitivity = YandexGame.savesData.mouseSensetivity;
        audioMixer.SetFloat("Full",YandexGame.savesData.fullVolume);
        audioMixer.SetFloat("Sound", YandexGame.savesData.soundVolume);
        audioMixer.SetFloat("Music", YandexGame.savesData.musicVolume);
    }
}
