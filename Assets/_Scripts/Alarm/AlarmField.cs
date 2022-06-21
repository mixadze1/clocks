using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using MyTime;

public class AlarmField : MonoBehaviour
{
    [SerializeField] private Text fieldTextHour;
    [SerializeField] private Text fieldTextMinute;
    [SerializeField] private GameObject errorOut;

    private int minuteStep = 59;
    private int hourStep = 23;
    private int twoDigitNumber = 10;

    private int hourAlarm;
    private int minuteAlarm;

    public void ClickChangeFieldHour()
    {
        try
        {
            int checkInt = int.Parse(fieldTextHour.text);
        }
        catch (System.Exception)
        {
            errorOut.SetActive(true);
            return;
        }

        int textInt = int.Parse(fieldTextHour.text);
        hourAlarm = textInt;
        

        if (hourAlarm >= 0 && hourAlarm <= hourStep)
        {
            PlayerPrefs.SetInt(MyTime.AlarmSave.HOUR, hourAlarm);
            return;
        }
        errorOut.SetActive(true);
    }

    public void ClickChangeFieldMinute()
    {
        try
        {
            int checkInt = int.Parse(fieldTextMinute.text);
        }
        catch (System.Exception)
        {
            errorOut.SetActive(true);
            return;
        }

        int textInt = int.Parse(fieldTextMinute.text);
        minuteAlarm = textInt;
        if (minuteAlarm >= 0 && minuteAlarm <= minuteStep)
        {
            PlayerPrefs.SetInt(MyTime.AlarmSave.MINUTE, minuteAlarm);
            return;
        }
        errorOut.SetActive(true);
    }
}
