using System.Collections;
using UnityEngine;
using MyTime;

public class Clock : MonoBehaviour
{

    [SerializeField] private DigitalClock digitalClock;
    [SerializeField] private HourArrow hourArrow;
    [SerializeField] private MinuteArrow minuteArrow;
    [SerializeField] private SecondArrow secondArrow;

    [SerializeField] private AlarmActivate alarmActivate;
    [SerializeField] private Alarm alarmController;
    [HideInInspector] protected int _hour;
    [HideInInspector] protected int _minute;
    [HideInInspector] protected int _second;

    private int hourStep = 23;
    private int minuteStep = 59;
    
    private Coroutine prepareRoutine;
    public int Hour => _hour;
    public int Minute => _minute;
    public int Second => _second;

    public void Init()
    {
        prepareRoutine = StartCoroutine(MoveClockEverySecond());
    }

    public void InitTime(int hour, int minute, int second)
    {
        _second = second;
        _minute = minute;
        _hour = hour;
    }

    private void Update()
    {
        if (IsAlarm())
        {
            alarmActivate.ActivateAlerm(); 
        }

    }

    private bool IsAlarm()
    {
        if (PlayerPrefs.GetInt(MyTime.AlarmSave.HOUR) == Hour &&
          PlayerPrefs.GetInt(MyTime.AlarmSave.MINUTE) == Minute &&
          alarmController.AlarmActive)
        {
            alarmController.AlarmActive = false;
            return true;
        }
        return false;
    }

    private IEnumerator MoveClockEverySecond()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Move();
        }
    }

    public void Move()
    {
        if (_second == minuteStep)
        {
            _second = 0;
            _minute++;
        }
        else
        {
            _second++;
        }

        if (_minute == minuteStep)
        {
            _minute = 0;
            _hour++;
        }
        if (_hour > hourStep)
        {
            _hour = 0;
        }
        secondArrow.MoveTime();
        minuteArrow.MoveTime();
        hourArrow.MoveTime();
        digitalClock.MoveTime();  
    }
}
