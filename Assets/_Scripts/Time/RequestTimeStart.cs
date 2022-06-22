using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RequestTimeStart : MonoBehaviour
{
    [SerializeField] private Clock _clock;
    [SerializeField] private HourRequest _hourRequest;

    [SerializeField] private List<string> _urls;

    private Response _response;

    public Coroutine PrepareRoutine;

    public List<string> Urls => _urls;

    private void Start()
    {
        PrepareRoutine = StartCoroutine(RequestTime(_urls));
    }

    public IEnumerator RequestTime(List<string> urls)
    {
        foreach( string url in urls)
        {
            UnityWebRequest webReq = UnityWebRequest.Get(url);
            yield return webReq.SendWebRequest();
            if (webReq != null)
            {
                ParseRequest(webReq);
                break;
            }
        }
    }

    private void ParseRequest(UnityWebRequest webReq)
    {
        _response = JsonUtility.FromJson<Response>(webReq.downloadHandler.text);
        var dateTime = DateTime.Parse(_response.datetime);      
        _hourRequest.EveryHourRequest();
        _clock.InitTime(dateTime.Hour, dateTime.Minute, dateTime.Second);
    }
}
