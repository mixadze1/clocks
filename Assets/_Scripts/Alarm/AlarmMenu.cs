using UnityEngine;

public class AlarmMenu : MonoBehaviour
{
    [SerializeField] private GameObject alarmMenu;
    [SerializeField] private GameObject alarm;
    [SerializeField] private GameObject accept;
    [SerializeField] private GameObject backClock;
    [SerializeField] private GameObject inCorrect;

    public void Alarm()
    {
        alarmMenu.SetActive(true);
    }

    public void AcceptAlerm()
    {
        alarmMenu.SetActive(false);
        alarm.SetActive(true);  
    }

    public void BackMenu()
    {
        alarmMenu.SetActive(false);
    }

    public void InCorrect()
    {
        inCorrect.SetActive(false);
    }
}
