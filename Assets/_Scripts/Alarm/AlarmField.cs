using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using MyTime;

public class AlarmField : MonoBehaviour
{
    [SerializeField] private Text _fieldTextHour;
    [SerializeField] private Text _fieldTextMinute;
    [SerializeField] private GameObject _errorOut;

    private int minuteStep = 59;
    private int hourStep = 23;

    private int hourAlarm;
    private int minuteAlarm;

    public void ClickChangeFieldHour()
    {
        try
        {
            int checkInt = int.Parse(_fieldTextHour.text);
        }
        catch (System.Exception)
        {
            _errorOut.SetActive(true);
            return;
        }

        int textInt = int.Parse(_fieldTextHour.text);
        hourAlarm = textInt;
        

        if (hourAlarm >= 0 && hourAlarm <= hourStep)
        {
            PlayerPrefs.SetInt(MyTime.AlarmSave.HOUR, hourAlarm);
            return;
        }
        _errorOut.SetActive(true);
    }

    public void ClickChangeFieldMinute()
    {
        try
        {
            int checkInt = int.Parse(_fieldTextMinute.text);
        }
        catch (System.Exception)
        {
            _errorOut.SetActive(true);
            return;
        }

        int textInt = int.Parse(_fieldTextMinute.text);
        minuteAlarm = textInt;
        if (minuteAlarm >= 0 && minuteAlarm <= minuteStep)
        {
            PlayerPrefs.SetInt(MyTime.AlarmSave.MINUTE, minuteAlarm);
            return;
        }
        _errorOut.SetActive(true);
    }
}
