using UnityEngine;

public class AlarmActivate : MonoBehaviour
{
    [SerializeField] private GameObject _alarmObj;
    [SerializeField] private GameObject _alarmNotification;
    [SerializeField] private Alarm _alarm;

    public void OffAlerm()
    {
        _alarm.AlarmActive = false;
        _alarmObj.SetActive(false);
    }

    public void ActivateAlerm()
    {
        _alarmNotification.SetActive(true);
        _alarm.AlarmActive = false;
    }

    public void offActiveAlerm()
    {
        _alarmNotification.SetActive(false);
        _alarm.AlarmActive = false;
        _alarmObj.SetActive(false);
    }
}
