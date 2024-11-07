using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class ChangeLanguage : MonoBehaviour
{
    [SerializeField] Sprite Rus;
    [SerializeField] Sprite Eng;
    [SerializeField] string RusText;
    [SerializeField] string EngText;

    private void Start()
    {
        if (Rus != null)
        {
            Image image = GetComponent<Image>();
            if (YandexGame.lang == "ru")
                image.sprite = Rus;
            else if (YandexGame.lang == "en")
                image.sprite = Eng;
        }
        if (RusText != "")
        {
            TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
            if (YandexGame.lang == "ru")
                text.text = RusText;
            else if (YandexGame.lang == "en")
                text.text = EngText;
        }
    }
}
