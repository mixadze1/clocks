using TMPro;
using UnityEngine;
using MyTime;

public class Alarm : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI hourTextAlerm;
    [SerializeField] private TextMeshProUGUI minuteTextAlerm;

    [SerializeField] private GameObject alarm;

    private int minuteStep = 59;
    private int hourStep = 23;
    private int twoDigitNumber = 10;

    private int hourAlarm;
    private int minuteAlarm;
   
    private bool alarmActive;
    public bool AlarmActive { get => alarmActive; set => alarmActive = value; }
/*    public int HourAlarm => hourAlarm;
    public int MinuteAlarm => minuteAlarm;*/

    public void AcceptAlerm()
    {
        alarm.SetActive(true);
        alarmActive = true;
        minuteAlarm = PlayerPrefs.GetInt((MyTime.AlarmSave.MINUTE));
        hourAlarm = PlayerPrefs.GetInt((MyTime.AlarmSave.HOUR));

        SetAlarm();
        
        ChangeTextAlarm();
    }
    private void SetAlarm()
    {
        PlayerPrefs.SetInt(MyTime.AlarmAccept.MINUTE, minuteAlarm);
        PlayerPrefs.SetInt(MyTime.AlarmAccept.HOUR, hourAlarm);
    }

    private void ChangeTextAlarm()
    {
        if (hourAlarm < twoDigitNumber)
        {
            hourTextAlerm.text = "0" + hourAlarm.ToString();
        }
        else
        {
            hourTextAlerm.text = hourAlarm.ToString();
        }

        if (minuteAlarm < twoDigitNumber)
        {
            minuteTextAlerm.text = "0" + minuteAlarm.ToString();
        }
        else
        {
            minuteTextAlerm.text = minuteAlarm.ToString();
        }
    }
}
