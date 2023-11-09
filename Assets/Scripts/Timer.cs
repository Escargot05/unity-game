using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Timer : MonoBehaviour
{
    private TextMeshProUGUI timer;
    private int hours;
    private int minutes;
    private int seconds;

    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<TextMeshProUGUI>();
        DisplayTime();
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

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

            seconds++;
            DisplayTime();
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
