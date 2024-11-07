using UnityEngine;
using YG;
using YG.Example;

public class SetRecord : MonoBehaviour
{
    private int a, b, c;
    private int d, e, f;

    private void OnEnable()
    {
        YandexGame.GetDataEvent += Load;
    }

    private void Start()
    {
        if (YandexGame.SDKEnabled)
            Load();
    }

    private void OnDisable()
    {
        YandexGame.GetDataEvent -= Load;
        int ans = a+b+c;
        YandexGame.NewLeaderboardScores("Leaderboar", ans);
    }

    private void Load()
    {
        a = YandexGame.savesData.maxKillsVillage;
        b = YandexGame.savesData.maxKillsMan;
        c = YandexGame.savesData.maxKillsDump;
    }
}
