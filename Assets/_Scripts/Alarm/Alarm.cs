using TMPro;
using UnityEngine;
using MyTime;

public class Alarm : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _hourTextAlerm;
    [SerializeField] private TextMeshProUGUI _minuteTextAlerm;

    [SerializeField] private GameObject _alarm;

    private int _twoDigitNumber = 10;
    private int _hourAlarm;
    private int _minuteAlarm;
   
    private bool _alarmActive;
    public bool AlarmActive { get => _alarmActive; set => _alarmActive = value; }
    public int HourAlarm => _hourAlarm;
    public int MinuteAlarm => _minuteAlarm;

    public void AcceptAlerm()
    {    
        SetAlarm();
        ChangeTextAlarm();
    }

    private void SetAlarm()
    {
        _alarm.SetActive(true);
        _alarmActive = true;
        _minuteAlarm = PlayerPrefs.GetInt((MyTime.AlarmSave.MINUTE));
        _hourAlarm = PlayerPrefs.GetInt((MyTime.AlarmSave.HOUR));
    }

    private void ChangeTextAlarm()
    {
        if (_hourAlarm < _twoDigitNumber)
        {
            _hourTextAlerm.text = "0" + _hourAlarm.ToString();
        }
        else
        {
            _hourTextAlerm.text = _hourAlarm.ToString();
        }

        if (_minuteAlarm < _twoDigitNumber)
        {
            _minuteTextAlerm.text = "0" + _minuteAlarm.ToString();
        }
        else
        {
            _minuteTextAlerm.text = _minuteAlarm.ToString();
        }
    }
}
