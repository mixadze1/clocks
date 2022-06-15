using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using MyTime;
public class RequestRealTime : MonoBehaviour
{
    [SerializeField] private Clock clock;
    [SerializeField] private EveryHourRequest hourRequest;
    Response response;

    private string urlFirst = "http://worldtimeapi.org/api/timezone/Europe/Moscow";
    private string urlSecond = "https://www.timeapi.io/api/Time/current/zone?timeZone=Europe/Moscow";

    public Coroutine PrepareRoutine;

    [HideInInspector] public int RealHour;
    [HideInInspector] public int RealMinute;
    [HideInInspector] public int RealSecond;

    public string UrlFirst => urlFirst;
    public string UrlSecond => urlSecond;

    public void Init()
    {
        PrepareRoutine = StartCoroutine(RequestTime(urlFirst,urlSecond));
    }

    public IEnumerator RequestTime(string url, string url2)
    {
        UnityWebRequest webReq = UnityWebRequest.Get(url);
        yield return webReq.SendWebRequest();

        if (webReq != null)
        {
            ServerRequest(webReq);
        }
        else
        {
            UnityWebRequest webReq2 = UnityWebRequest.Get(url2);
            yield return webReq2.SendWebRequest();
            ServerRequest(webReq);
        }
    }

    private void ServerRequest(UnityWebRequest webReq)
    {
        response = JsonUtility.FromJson<Response>(webReq.downloadHandler.text);
        var dateTime = DateTime.Parse(response.datetime);
        SaveTime(dateTime.Hour, dateTime.Minute, dateTime.Second); 
        HourRequest();
    }

    private void HourRequest()
    {
        if (hourRequest.PrepareRoutine != null)
        {
            hourRequest.StopCoroutine(hourRequest.PrepareRoutine);
        }
        hourRequest.PrepareRoutine = StartCoroutine(hourRequest.OneHour());
    }

    private void SaveTime(int hour, int minute, int second)
    {
        PlayerPrefs.SetInt(MyTime.Real.SECOND, second);
        PlayerPrefs.SetInt(MyTime.Real.MINUTE, minute);
        PlayerPrefs.SetInt(MyTime.Real.HOUR, hour);
        clock.TimeCheck();
    }
}
