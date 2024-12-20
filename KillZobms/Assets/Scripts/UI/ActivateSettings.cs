    using Unity.VisualScripting;
using UnityEngine;
using YG;

public class ActivateSettings : MonoBehaviour
{
    [SerializeField] GameObject settings;
    [SerializeField] GameObject LoseMenu;
    [SerializeField] GameObject WinUI;

    private void OnEnable()
    {
        YandexGame.onVisibilityWindowGame += OnVisibillity;
        YandexGame.OpenFullAdEvent += ActivateFromAd;
    }
    private void OnDisable()
    {
        YandexGame.OpenFullAdEvent -= ActivateFromAd;
        YandexGame.onVisibilityWindowGame -= OnVisibillity;
    }

    private void OnVisibillity(bool visible)
    {
        if (!visible) settings.SetActive(true);
    }

    public void Activate()
    {
        settings.SetActive(true);

    }

    private void ActivateFromAd()
    {
        settings.SetActive(true);

    }

    void Update()
    {
        if (!LoseMenu.activeSelf && !WinUI.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Tab) && !settings.activeSelf)
            {
                settings.SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.Tab) && settings.activeSelf)
            {
                settings.SetActive(false);
            }
        }
    }
}
