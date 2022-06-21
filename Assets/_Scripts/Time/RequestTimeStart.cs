using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class RequestTimeStart : MonoBehaviour
{
    [SerializeField] private Clock _clock;
    [SerializeField] private HourRequest _hourRequest;

    private string _urlFirst = "http://worldtimeapi.org/api/timezone/Europe/Moscow";
    private string _urlSecond = "https://www.timeapi.io/api/Time/current/zone?timeZone=Europe/Moscow";
    private Response _response;

    public Coroutine PrepareRoutine;

    public string UrlFirst => _urlFirst;
    public string UrlSecond => _urlSecond;

    public void Start()
    {
        _clock.Init();
        PrepareRoutine = StartCoroutine(RequestTime(_urlFirst,_urlSecond));
    }

    public IEnumerator RequestTime(string url, string url2)
    {
        UnityWebRequest webReq = UnityWebRequest.Get(url);
        yield return webReq.SendWebRequest();

        if (webReq != null)
        {
            ParseRequest(webReq);
        }
        else
        {
            UnityWebRequest webReq2 = UnityWebRequest.Get(url2);
            yield return webReq2.SendWebRequest();
            ParseRequest(webReq);
        }
    }

    private void ParseRequest(UnityWebRequest webReq)
    {
        _response = JsonUtility.FromJson<Response>(webReq.downloadHandler.text);
        var dateTime = DateTime.Parse(_response.datetime);
        _clock.InitTime(dateTime.Hour, dateTime.Minute, dateTime.Second);
        _hourRequest.EveryHourRequest();
    }

}
