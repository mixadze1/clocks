using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AlarmButtons : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI _hourText;
    [SerializeField] protected TextMeshProUGUI _minutesText;

    private int _minuteStep = 59;
    private int _hourStep = 23;
    private int _twoDigitNumber = 10;

    private int _hourAlarm;
    private int _minuteAlarm;

    public void clickHourUp()
    {
        if (_hourAlarm >= _hourStep)
        {
            _hourAlarm = 0;
        }
        else
        {
            _hourAlarm++;
        }
        if (_hourAlarm < _twoDigitNumber)
        {
            _hourText.text = "0" + _hourAlarm.ToString();
        }
        else
        {
            _hourText.text = _hourAlarm.ToString();
        }
        PlayerPrefs.SetInt(MyTime.AlarmSave.HOUR, _hourAlarm);

    }

    public void clickHourDown()
    {
        if (_hourAlarm <= 0)
        {
            _hourAlarm = _hourStep;
        }
        else
        {
            _hourAlarm--;
        }

        if (_hourAlarm < _twoDigitNumber)
        {
            _hourText.text = "0" + _hourAlarm.ToString();
        }
        else
        {
            _hourText.text = _hourAlarm.ToString();
        }
        PlayerPrefs.SetInt(MyTime.AlarmSave.HOUR, _hourAlarm);
    }

    public void clickMinuteUp()
    {
        if (_minuteAlarm >= _minuteStep)
        {
            _minuteAlarm = 0;
        }
        else
        {
            _minuteAlarm++;
        }
        
        if (_minuteAlarm < _twoDigitNumber)
        {
            _minutesText.text = "0" + _minuteAlarm.ToString();
        }
        else
        {
            _minutesText.text = _minuteAlarm.ToString();
        }
        PlayerPrefs.SetInt(MyTime.AlarmSave.MINUTE, _minuteAlarm);
    }

    public void clickMinuteDown()
    {
        if (_minuteAlarm <= 0)
        {
            _minuteAlarm = _minuteStep;
        }
        else
        {
            _minuteAlarm--;
        }

        if (_minuteAlarm < _twoDigitNumber)
        {
            _minutesText.text = "0" + _minuteAlarm.ToString();
        }
        else
        {
            _minutesText.text = _minuteAlarm.ToString();
        }
        PlayerPrefs.SetInt(MyTime.AlarmSave.MINUTE, _minuteAlarm);
    }
}
