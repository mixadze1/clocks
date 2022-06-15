using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EveryHourRequest : MonoBehaviour
{
    [SerializeField] private RequestRealTime requestTime;
    public Coroutine PrepareRoutine;

    public IEnumerator OneHour()
    {
        float hour = 0;
        while (hour <= 3600)
        {
            yield return new WaitForSecondsRealtime(1);
            hour++;
        }
        requestTime.StopCoroutine(requestTime.PrepareRoutine);
        requestTime.PrepareRoutine = StartCoroutine(requestTime.RequestTime(requestTime.UrlFirst, requestTime.UrlSecond));
    }
}
