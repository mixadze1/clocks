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

    private int _hour;
    private int _minute;
    private int _second;

    private int _hourStep = 23;
    private int _minuteStep = 59;
    
    private Coroutine prepareRoutine;
    public int Hour => _hour;
    public int Minute => _minute;
    public int Second => _second;
    public void InitTime(int hour, int minute, int second)
    {
        _second = second;
        _minute = minute;
        _hour = hour; 
        prepareRoutine = StartCoroutine(MoveClockEverySecond());
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

    private void Move()
    {
        if (_second == _minuteStep)
        {
            _second = 0;
            _minute++;
        }
        else
        {
            _second++;
        }

        if (_minute == _minuteStep)
        {
            _minute = 0;
            _hour++;
        }
        if (_hour > _hourStep)
        {
            _hour = 0;
        }
        _secondArrow.MoveTime();
        _minuteArrow.MoveTime();
        _hourArrow.MoveTime();
        _digitalClock.MoveTime();  
    }
}
