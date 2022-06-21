using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class RequestTimeStart : MonoBehaviour
{
    [SerializeField] private Clock clock;
    [SerializeField] private HourRequest hourRequest;

    private string urlFirst = "http://worldtimeapi.org/api/timezone/Europe/Moscow";
    private string urlSecond = "https://www.timeapi.io/api/Time/current/zone?timeZone=Europe/Moscow";
    private Response response;

    public Coroutine PrepareRoutine;

    [HideInInspector] public int RealHour;
    [HideInInspector] public int RealMinute;
    [HideInInspector] public int RealSecond;

    public string UrlFirst => urlFirst;
    public string UrlSecond => urlSecond;

    public void Start()
    {
        clock.Init();
        PrepareRoutine = StartCoroutine(RequestTime(urlFirst,urlSecond));
    }

    public IEnumerator RequestTime(string url, string url2)
    {
        UnityWebRequest webReq = UnityWebRequest.Get(url);
        yield return webReq.SendWebRequest();

        if (webReq != null)
        {
            ParseTime(webReq);
        }
        else
        {
            UnityWebRequest webReq2 = UnityWebRequest.Get(url2);
            yield return webReq2.SendWebRequest();
            ParseTime(webReq);
        }
    }

    private void ParseTime(UnityWebRequest webReq)
    {
        response = JsonUtility.FromJson<Response>(webReq.downloadHandler.text);
        var dateTime = DateTime.Parse(response.datetime);
        clock.InitTime(dateTime.Hour, dateTime.Minute, dateTime.Second);
        hourRequest.EveryHourRequest();
    }

}
