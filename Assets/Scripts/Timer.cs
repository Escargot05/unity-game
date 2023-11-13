using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Timer : MonoBehaviour
{
    TextMeshProUGUI timer;
    int hours;
    int minutes;
    int seconds;
    float time;

    private void Awake()
    {
        timer = GetComponent<TextMeshProUGUI>();
        time = 0.0f;
    }

    private void Update()
    {
        DisplayTime();
        time += Time.deltaTime;

        if (time >= 1.0f)
        {
            if (seconds == 60)
            {
                if (minutes == 60)
                {
                    hours++;
                    minutes = 0;
                }
                seconds = 0;
                minutes++;
            }
            time = 0.0f;
            seconds++;
        }
    }

    private void DisplayTime()
    {
        string sec = seconds >= 10 ? seconds.ToString() : $"0{seconds}";
        string min = minutes >= 10 ? minutes.ToString() : $"0{minutes}";
        string h = hours >= 10 ? hours.ToString() : $"0{hours}";

        timer.text = $"{h}:{min}:{sec}";
    }
}
