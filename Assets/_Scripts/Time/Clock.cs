using System;
using System.Collections;
using UnityEngine;
using MyTime;
public class Clock : MonoBehaviour
{
    [SerializeField] private RequestRealTime requestRealTime;
    [SerializeField] private DigitalClock digitalClock;

    [SerializeField] private HourArrow hourArrow;
    [SerializeField] private MinuteArrow minuteArrow;
    [SerializeField] private SecondArrow secondArrow;

    [SerializeField] private AlarmActivate alarmActivate;
    [SerializeField] private AlarmController alarmController;
    [HideInInspector] protected int hour;
    [HideInInspector] protected int minute;
    [HideInInspector] protected int second;

    private int hourStep = 23;
    private int minuteStep = 59;
    
    private Coroutine prepareRoutine;
    public int Hour => hour;
    public int Minute => minute;
    public int Second => second;

    private void Start()
    {
        requestRealTime.Init();
        prepareRoutine = StartCoroutine(WaitingSecond());
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt(MyTime.Alarm.HOUR) == Hour &&
            PlayerPrefs.GetInt(MyTime.Alarm.MINUTE) == Minute && 
            alarmController.AlarmActive)
        {
            alarmActivate.ActivateAlerm();
        }
    }
    public void TimeCheck()
    {
        hour = PlayerPrefs.GetInt(MyTime.Real.HOUR);
        minute = PlayerPrefs.GetInt(MyTime.Real.MINUTE);
        second = PlayerPrefs.GetInt(MyTime.Real.SECOND);
    }

    IEnumerator WaitingSecond()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            MoveTime();
        }
    }

    public void MoveTime()
    {
        if (second == minuteStep)
        {
            second = 0;
            minute++;
        }
        else
        {
            second++;
        }

        if (minute == minuteStep)
        {
            minute = 0;
            hour++;
        }
        if (hour > hourStep)
        {
            hour = 0;
        }
        digitalClock.MoveTime();
        hourArrow.MoveTime();
        minuteArrow.MoveTime();
        secondArrow.MoveTime();
    }
}
