using System.Collections;
using UnityEngine;
using MyTime;

public class Clock : MonoBehaviour
{

    [SerializeField] private DigitalClock _digitalClock;
    [SerializeField] private ArrowHour _hourArrow;
    [SerializeField] private ArrowMinute _minuteArrow;
    [SerializeField] private ArrowSecond _secondArrow;

    [SerializeField] private AlarmActivate _alarmActivate;
    [SerializeField] private Alarm _alarm;
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
            _alarmActivate.ActivateAlerm(); 
        }

    }

    private bool IsAlarm()
    {
        if (_alarm.HourAlarm == Hour &&
          _alarm.MinuteAlarm == Minute &&
          _alarm.AlarmActive)
        {
            _alarm.AlarmActive = false;
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
        _secondArrow.MoveTime();
        _minuteArrow.MoveTime();
        _hourArrow.MoveTime();
        _digitalClock.MoveTime();  
    }
}
