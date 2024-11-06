using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveState : MonoBehaviour
{
    public static int waveCount;
    public static bool isRest=true;
    [SerializeField] TextMeshProUGUI waveCountText;
    [SerializeField] GameObject helpUI;
    public static int zombiesCount;
    [SerializeField] TextMeshProUGUI zombiesCountText;

    

    private void Update()
    {
        if (!isRest)
        {
            waveCountText.text = waveCount.ToString();
            zombiesCountText.text = zombiesCount.ToString();
            helpUI.SetActive(false);
        }
        else
        {
            helpUI.SetActive(true);
            zombiesCountText.text = "-";
            waveCountText.text = "-";
        }
    }

}
