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

    private int _minuteStep = 59;
    private int _hourStep = 23;

    private int _hourAlarm;
    private int _minuteAlarm;

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
        _hourAlarm = textInt;
        

        if (_hourAlarm >= 0 && _hourAlarm <= _hourStep)
        {
            PlayerPrefs.SetInt(MyTime.AlarmSave.HOUR, _hourAlarm);
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
        _minuteAlarm = textInt;
        if (_minuteAlarm >= 0 && _minuteAlarm <= _minuteStep)
        {
            PlayerPrefs.SetInt(MyTime.AlarmSave.MINUTE, _minuteAlarm);
            return;
        }
        _errorOut.SetActive(true);
    }
}
