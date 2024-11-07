using UnityEngine;
using YG;

public class MakeInfiniteActive : MonoBehaviour
{
    [SerializeField] PlaceType placeType;
    private int isVillageClean;
    private int isMansionClean;
    private int isDumpClean;
    [SerializeField] GameObject Close;


    enum PlaceType { village,mansion,dump}

    private void OnEnable()
    {
        YandexGame.GetDataEvent += GetLoad;

        if (YandexGame.SDKEnabled)
            GetLoad();
        if (isVillageClean == 1 && placeType == PlaceType.village)
            Close.SetActive(false);
        if (isDumpClean == 1 && placeType == PlaceType.dump)
            Close.SetActive(false);
        if (isMansionClean == 1 && placeType == PlaceType.mansion)
            Close.SetActive(false);
    }

    private void OnDisable()
    {
        YandexGame.GetDataEvent -= GetLoad;
    }

   

    private void GetLoad()
    {
        isVillageClean = YandexGame.savesData.isVillageClean;
        isDumpClean = YandexGame.savesData.isDumpClean;
        isMansionClean = YandexGame.savesData.isMansionClean;
    }
}
