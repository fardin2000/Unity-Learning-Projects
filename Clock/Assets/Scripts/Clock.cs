using System;
using UnityEngine;

public class Clock : MonoBehaviour
{

    const float hoursToDegrees = -30f, minutesToDegrees = -6f, secondsToDegrees = -6f;

    [SerializeField]
    Transform hoursPivot = default, minutesPivot = default, secondsPivot = default;

    private void Update()
    {
        TimeSpan time = DateTime.Now.TimeOfDay;
        hoursPivot.localRotation = Quaternion.Euler(0f, 0f, (float)(hoursToDegrees * time.TotalHours));
        minutesPivot.localRotation = Quaternion.Euler(0f, 0f, (float)(minutesToDegrees * time.TotalMinutes));
        secondsPivot.localRotation = Quaternion.Euler(0f, 0f, (float)(secondsToDegrees * time.TotalSeconds));
    }

}