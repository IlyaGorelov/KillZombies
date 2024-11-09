using TMPro;
using UnityEngine;

public class InfWaveState : MonoBehaviour
{
    public static int kills;
    [SerializeField] TextMeshProUGUI killText;
    [SerializeField] TextMeshProUGUI timeText;
    private float time = 0;
    public static int zombiesCount;

    private void Update()
    {
        time += Time.deltaTime;
        timeText.text = time.ToString("0.00");
        killText.text=kills.ToString();

    }

    private void OnDisable()
    {
        zombiesCount = 0;
        kills = 0;
        time = 0;
    }
}
