using TMPro;
using UnityEngine;
using MyTime;

public class Alarm : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _hourTextAlerm;
    [SerializeField] private TextMeshProUGUI _minuteTextAlerm;

    [SerializeField] private GameObject _alarm;

    private int twoDigitNumber = 10;
    private int hourAlarm;
    private int minuteAlarm;
   
    private bool alarmActive;
    public bool AlarmActive { get => alarmActive; set => alarmActive = value; }
    public int HourAlarm => hourAlarm;
    public int MinuteAlarm => minuteAlarm;

    public void AcceptAlerm()
    {    
        SetAlarm();
        ChangeTextAlarm();
    }

    private void SetAlarm()
    {
        _alarm.SetActive(true);
        alarmActive = true;
        minuteAlarm = PlayerPrefs.GetInt((MyTime.AlarmSave.MINUTE));
        hourAlarm = PlayerPrefs.GetInt((MyTime.AlarmSave.HOUR));
    }

    private void ChangeTextAlarm()
    {
        if (hourAlarm < twoDigitNumber)
        {
            _hourTextAlerm.text = "0" + hourAlarm.ToString();
        }
        else
        {
            _hourTextAlerm.text = hourAlarm.ToString();
        }

        if (minuteAlarm < twoDigitNumber)
        {
            _minuteTextAlerm.text = "0" + minuteAlarm.ToString();
        }
        else
        {
            _minuteTextAlerm.text = minuteAlarm.ToString();
        }
    }
}
