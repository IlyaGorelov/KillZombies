using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] GameObject loadUI;
    [SerializeField] Slider slider;
    private int levelId;

    private void OnEnable()
    {
        YandexGame.CloseFullAdEvent += LoadAfterAd;
    }

    private void OnDisable()
    {
        YandexGame.CloseFullAdEvent -= LoadAfterAd;
    }



    public void Load(int level)
    {
        levelId = level;
        print(levelId);
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            loadUI.SetActive(true);
            StartCoroutine(LoadLevelAsync());

        }
        else
            YandexGame.FullscreenShow();
    }

    private void LoadAfterAd()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            loadUI.SetActive(true);
            StartCoroutine(LoadLevelAsync());

        }
    }

    IEnumerator LoadLevelAsync()
    {
        AsyncOperation load = SceneManager.LoadSceneAsync(levelId);


        while (!load.isDone)
        {
            slider.value = load.progress;

            yield return null;
        }
    }
}
