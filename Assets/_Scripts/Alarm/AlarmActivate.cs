using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using MyTime;
using System;

public class AlarmActivate : MonoBehaviour
{
    [SerializeField] private GameObject alarm;
    [SerializeField] private GameObject alarmNotification;
    [SerializeField] private AlarmController alarmController;

    public void OffAlerm()
    {
        alarmController.AlarmActive = false;
        alarm.SetActive(false);
    }

    public void ActivateAlerm()
    {
        alarmNotification.SetActive(true);
        alarmController.AlarmActive = false;
    }

    public void offActiveAlerm()
    {
        alarmNotification.SetActive(false);
        alarmController.AlarmActive = false;
        alarm.SetActive(false);
    }
}
