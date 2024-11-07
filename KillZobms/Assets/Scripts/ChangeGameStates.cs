using UnityEngine;
using YG;

public class ChangeGameStates : MonoBehaviour
{
    void Update()
    {
        if (Time.timeScale == 1)
            YandexGame.GameplayStart();
        else YandexGame.GameplayStop();
    }
}
