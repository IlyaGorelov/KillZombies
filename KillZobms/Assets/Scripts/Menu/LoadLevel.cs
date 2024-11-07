using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] GameObject loadUI;
    [SerializeField] Slider slider;

    public void Load(int level)
    {
        loadUI.SetActive(true);
        StartCoroutine(LoadLevelAsync(level));
    }

    IEnumerator LoadLevelAsync(int levelId)
    {
        AsyncOperation load =  SceneManager.LoadSceneAsync(levelId);


        while (!load.isDone)
        {
            slider.value = load.progress;

            yield return null;
        }
    }
}
