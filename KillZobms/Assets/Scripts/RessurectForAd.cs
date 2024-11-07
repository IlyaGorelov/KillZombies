using UnityEngine;
using YG;
using YG.Example;

public class RessurectForAd : MonoBehaviour
{
    [SerializeField] CharacterHealth health;
    [SerializeField] GameObject LoseScreen;
    [SerializeField] GameObject SetScreen;

    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += Rewarded;
    }

    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= Rewarded;
    }

    private void Rewarded(int id)
    {
        if (id == 0)
        {
            SetScreen.SetActive(true);
            LoseScreen.SetActive(false);
            health.gameObject.transform.Translate(0, 50, 0);
            health.health = 100;
            
        }
    }

    public void ShowAd()
    {
        YandexGame.RewVideoShow(0);
    }
}
