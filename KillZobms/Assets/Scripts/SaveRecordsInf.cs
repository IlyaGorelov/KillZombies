using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class SaveRecordsInf : MonoBehaviour
{
    int prevMaxKills = 0;
    [SerializeField] TextMeshProUGUI killsText;
    [SerializeField] TextMeshProUGUI time;

    private void OnEnable()
    {
        YandexGame.GetDataEvent += LoadVillage;
        YandexGame.GetDataEvent += LoadMansion;
    }
    private void Start()
    {
        if (YandexGame.SDKEnabled)
        {
            if(SceneManager.GetActiveScene().buildIndex == 2)
            LoadVillage();
            if (SceneManager.GetActiveScene().buildIndex == 4)
            {
                LoadMansion();
            }
            if (SceneManager.GetActiveScene().buildIndex == 6)
            {
                LoadDump();
            }
        }
    }

    void OnDisable()
    {
        YandexGame.GetDataEvent -= LoadVillage;
        YandexGame.GetDataEvent -= LoadMansion;

        if (SceneManager.GetActiveScene().buildIndex== 2)
        {
            SaveVillage();
        }
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            SaveMansion();
        }
        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            SaveDump();
        }
    }

    private void SaveVillage()
    {
        if (prevMaxKills < Convert.ToInt32(killsText.text))
        {
            YandexGame.savesData.maxKillsVillage = Convert.ToInt32(killsText.text);
            YandexGame.savesData.timeVillage = Convert.ToInt32(time.text.Split(',')[0]);
            YandexGame.SaveProgress();
        }
    }

    private void SaveDump()
    {
        if (prevMaxKills < Convert.ToInt32(killsText.text))
        {
            YandexGame.savesData.maxKillsDump = Convert.ToInt32(killsText.text);
            YandexGame.savesData.timeDump = Convert.ToInt32(time.text.Split(',')[0]);
            YandexGame.SaveProgress();
        }
    }

    private void SaveMansion()
    {
        if (prevMaxKills < Convert.ToInt32(killsText.text))
        {
            YandexGame.savesData.maxKillsMan = Convert.ToInt32(killsText.text);
            YandexGame.savesData.timeMan = Convert.ToInt32(time.text.Split(',')[0]);
            YandexGame.SaveProgress();
        }
    }

    private void LoadVillage()
    {
        prevMaxKills=YandexGame.savesData.maxKillsVillage;
    }
    private void LoadDump()
    {
        prevMaxKills = YandexGame.savesData.maxKillsDump;
    }
    private void LoadMansion()
    {
        prevMaxKills = YandexGame.savesData.maxKillsMan;
    }
}
