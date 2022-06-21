using System.Collections;
using UnityEngine;

public class HourRequest : MonoBehaviour
{
    [SerializeField] private RequestTimeStart requestTime;
    private Coroutine PrepareRoutine;

    public void EveryHourRequest()
    {
        if (PrepareRoutine != null)
        {
            StopCoroutine(PrepareRoutine);
        }
        PrepareRoutine = StartCoroutine(OneHour());
    }

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
