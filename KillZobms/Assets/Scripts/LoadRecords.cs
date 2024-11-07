using YG;
using TMPro;
using UnityEngine;
using Unity.VisualScripting;

public class LoadRecords : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI maxScore;
    [SerializeField] TextMeshProUGUI time;
    [SerializeField] PlaceType placeType;

    enum PlaceType { village,mansion,dump}

    private void OnEnable()
    {
        YandexGame.GetDataEvent += Load;
        if (YandexGame.SDKEnabled) Load();
    }

    private void OnDisable()
    {
        YandexGame.GetDataEvent -= Load;
    }


    private void Load()
    {
        switch (placeType)
        {
            case PlaceType.village:
        maxScore.text = YandexGame.savesData.maxKillsVillage.ToString();
                time.text= YandexGame.savesData.timeVillage.ToString();
                break;
            case PlaceType.mansion:
                maxScore.text = YandexGame.savesData.maxKillsMan.ToString();
                time.text = YandexGame.savesData.timeMan.ToString();
                break;
            case PlaceType.dump:
                maxScore.text = YandexGame.savesData.maxKillsDump.ToString();
                time.text = YandexGame.savesData.timeDump.ToString();
                break;
        }

    }
}
