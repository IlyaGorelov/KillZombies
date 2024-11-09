using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using YG;

public class ToMenu : MonoBehaviour
{
    [SerializeField] GameObject loadUI;
    [SerializeField] Slider slider;

    public void Load()
    {
        loadUI.SetActive(true);
        StartCoroutine(LoadLevelAsync());
    }


    IEnumerator LoadLevelAsync()
    {
        AsyncOperation load = SceneManager.LoadSceneAsync(0);


        while (!load.isDone)
        {
            slider.value = load.progress;

            yield return null;
        }
    }
}
