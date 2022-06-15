using TMPro;
using UnityEngine;
using UnityEngine.UI;
using MyTime;
public class AlarmController : MonoBehaviour
{
    [SerializeField] private Text fieldTextHour;
    [SerializeField] private Text fieldTextMinute;

    [SerializeField] protected TextMeshProUGUI hourTextAlerm;
    [SerializeField] protected TextMeshProUGUI minuteTextAlerm;
    [SerializeField] protected TextMeshProUGUI hourText;
    [SerializeField] protected TextMeshProUGUI minutesText;

    [SerializeField] private GameObject alerm;
    [SerializeField] private GameObject errorOut;

    private int minuteStep = 59;
    private int hourStep = 23;
    private int twoDigitNumber = 10;

    private int hourAlarm;
    private int minuteAlarm;
   
    private bool alarmActive;
    public bool AlarmActive { get => alarmActive; set => alarmActive = value; }

    public void Init()
    {
        hourText.text = "00";
        minutesText.text = "00";
    }

    public void clickHourUp()
    {
        if (hourAlarm >= hourStep)
        {
            hourAlarm = 0;
        }
        else
        {
            hourAlarm++;
        }

        PlayerPrefs.SetInt(MyTime.AlarmChange.HOUR, hourAlarm);
        if (hourAlarm < twoDigitNumber)
        {
            hourText.text = "0" + hourAlarm.ToString();
        }    
        else
        {
            hourText.text = hourAlarm.ToString();
        }
           
    }

    public void clickHourDown()
    {
        if (hourAlarm <= 0)
        {
            hourAlarm = hourStep;
        }
          
        else
        {
            hourAlarm--;
        }
        PlayerPrefs.SetInt(MyTime.AlarmChange.HOUR, hourAlarm);
        if (hourAlarm < twoDigitNumber)
        {
            hourText.text = "0" + hourAlarm.ToString();
        }
           
        else
        {
            hourText.text = hourAlarm.ToString();
        }
             
    }

    public void clickMinuteUp()
    {
        if (minuteAlarm >= minuteStep)
        {
            minuteAlarm = 0;
        }
       
        else
        {
            minuteAlarm++;
        }

        PlayerPrefs.SetInt(MyTime.AlarmChange.MINUTE, minuteAlarm);
        if (minuteAlarm < twoDigitNumber)
        {
            minutesText.text = "0" + minuteAlarm.ToString();
        }
           
        else
        {
            minutesText.text = minuteAlarm.ToString();
        }
           
    }

    public void clickMinuteDown()
    {
        if (minuteAlarm <= 0)
        {
            minuteAlarm = minuteStep;
        }  
        else
        {
            minuteAlarm--;
        }
         
        PlayerPrefs.SetInt(MyTime.AlarmChange.MINUTE, minuteAlarm);

        if (minuteAlarm < twoDigitNumber)
        {
            minutesText.text = "0" + minuteAlarm.ToString();
        }
        else
        {
            minutesText.text = minuteAlarm.ToString();
        }
           
    }

    public void ClickChangeFieldHour()
    {
        try
        {
            int checkInt = int.Parse(fieldTextHour.text);
        }
        catch (System.Exception)
        {
            errorOut.SetActive(true);
            return;
        }

        int textInt = int.Parse(fieldTextHour.text);
        hourAlarm = textInt;
        PlayerPrefs.SetInt(MyTime.AlarmChange.HOUR, hourAlarm);

        if (hourAlarm >= 0 && hourAlarm <= hourStep)
        {
            if (hourAlarm < twoDigitNumber)
            {
                hourText.text = "0" + hourAlarm.ToString();
            }
             
            else
            {
                hourText.text = hourAlarm.ToString();
            }
            Debug.Log(hourAlarm);
        }
        else
        {
            errorOut.SetActive(true);
        }   
    }

    public void ClickChangeFieldMinute()
    {    
        try
        {
           int checkInt = int.Parse(fieldTextMinute.text);
        }
        catch (System.Exception)
        {
            errorOut.SetActive(true);
            return;
        }

        int textInt = int.Parse(fieldTextMinute.text);
        minuteAlarm = textInt;
        PlayerPrefs.SetInt(MyTime.AlarmChange.MINUTE, minuteAlarm);
        if (minuteAlarm >= 0 && minuteAlarm <= minuteStep)
        {
            if (minuteAlarm < twoDigitNumber)
            {
                minutesText.text = "0" + minuteAlarm.ToString();
            }
            else
            {
                minutesText.text = minuteAlarm.ToString();
            }   
        }
        else
        {
            errorOut.SetActive(true);
        }
           
    }

    public void AcceptAlerm()
    {
        alerm.SetActive(true);
        alarmActive = true;
        PlayerPrefs.SetInt((MyTime.AlarmAccept.MINUTE), minuteAlarm);
        PlayerPrefs.SetInt((MyTime.AlarmAccept.HOUR), hourAlarm);

        if (hourAlarm < twoDigitNumber)
        {
            hourTextAlerm.text = "0" + hourAlarm.ToString();
        }    
        else
        {
            hourTextAlerm.text = hourAlarm.ToString();
        }

        if (minuteAlarm < twoDigitNumber)
        {
            minuteTextAlerm.text = "0" + minuteAlarm.ToString();
        }
        else
        {
            minuteTextAlerm.text = minuteAlarm.ToString();
        }
    }
}
