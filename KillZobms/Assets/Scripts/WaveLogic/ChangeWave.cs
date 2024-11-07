using System;
using TMPro;
using UnityEngine;

public class ChangeWave : MonoBehaviour
{
    [SerializeField] GameObject timer;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float maxSeconds;
    private float seconds;

    

    private void Start()
    {
        seconds = maxSeconds;
    }

    void Update()
    {
        if (WaveState.isRest)
        {
            timer.SetActive(true);
            timerText.text = seconds.ToString("0.00");
            seconds -= Time.deltaTime;
        }
        else
        {
            seconds = maxSeconds;
            timer.SetActive(false);
        }

      

        if (seconds <= 0||Input.GetKeyDown(KeyCode.N))
        {
            if (WaveState.isRest)
            {
            WaveState.isRest = false;
            WaveState.waveCount += 1;

            }
        }
    }
}
