using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AlarmButton : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI _hourText;
    [SerializeField] protected TextMeshProUGUI _minutesText;

    private int minuteStep = 59;
    private int hourStep = 23;
    private int twoDigitNumber = 10;

    private int hourAlarm;
    private int minuteAlarm;

    public void clickHourUp()
    {
        if (hourAlarm >= hourStep)
        {
            hourAlarm = 0;
        }
        else
        {
            hourAlarm++;
        }
        if (hourAlarm < twoDigitNumber)
        {
            _hourText.text = "0" + hourAlarm.ToString();
        }
        else
        {
            _hourText.text = hourAlarm.ToString();
        }
        PlayerPrefs.SetInt(MyTime.AlarmSave.HOUR, hourAlarm);

    }

    public void clickHourDown()
    {
        if (hourAlarm <= 0)
        {
            hourAlarm = hourStep;
        }
        else
        {
            hourAlarm--;
        }

        if (hourAlarm < twoDigitNumber)
        {
            _hourText.text = "0" + hourAlarm.ToString();
        }
        else
        {
            _hourText.text = hourAlarm.ToString();
        }
        PlayerPrefs.SetInt(MyTime.AlarmSave.HOUR, hourAlarm);
    }

    public void clickMinuteUp()
    {
        if (minuteAlarm >= minuteStep)
        {
            minuteAlarm = 0;
        }
        else
        {
            minuteAlarm++;
        }
        
        if (minuteAlarm < twoDigitNumber)
        {
            _minutesText.text = "0" + minuteAlarm.ToString();
        }
        else
        {
            _minutesText.text = minuteAlarm.ToString();
        }
        PlayerPrefs.SetInt(MyTime.AlarmSave.MINUTE, minuteAlarm);
    }

    public void clickMinuteDown()
    {
        if (minuteAlarm <= 0)
        {
            minuteAlarm = minuteStep;
        }
        else
        {
            minuteAlarm--;
        }

        if (minuteAlarm < twoDigitNumber)
        {
            _minutesText.text = "0" + minuteAlarm.ToString();
        }
        else
        {
            _minutesText.text = minuteAlarm.ToString();
        }
        PlayerPrefs.SetInt(MyTime.AlarmSave.MINUTE, minuteAlarm);
    }
}
