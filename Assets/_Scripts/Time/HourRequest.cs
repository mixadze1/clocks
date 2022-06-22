using System.Collections;
using UnityEngine;

public class HourRequest : MonoBehaviour
{
    [SerializeField] private RequestTimeStart _requestTime;
    private Coroutine _PrepareRoutine;

    public void EveryHourRequest()
    {
        if (_PrepareRoutine != null)
        {
            StopCoroutine(_PrepareRoutine);
        }
        _PrepareRoutine = StartCoroutine(OneHour());
    }

    private IEnumerator OneHour()
    {
        float hour = 0;
        while (hour <= 3600)
        {
            yield return new WaitForSecondsRealtime(1);
            hour++;
        }
        _requestTime.StopCoroutine(_requestTime.PrepareRoutine);
        _requestTime.PrepareRoutine = StartCoroutine(_requestTime.RequestTime(_requestTime.Urls));
    }
}
