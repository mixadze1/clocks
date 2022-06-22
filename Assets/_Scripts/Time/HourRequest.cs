using System.Collections;
using UnityEngine;

public class HourRequest : MonoBehaviour
{
    [SerializeField] private RequestTimeStart _requestTime;
    private Coroutine _PrepareRoutine;
    private float _hour = 3600;

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
        float count = 0;
        while (count <= _hour)
        {
            yield return new WaitForSecondsRealtime(1);
            count++;
        }
        _requestTime.StopCoroutine(_requestTime.PrepareRoutine);
        _requestTime.PrepareRoutine = StartCoroutine(_requestTime.RequestTime(_requestTime.Urls));
    }
}
