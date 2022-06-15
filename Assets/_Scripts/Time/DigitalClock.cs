using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DigitalClock : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hourText;
    [SerializeField] private TextMeshProUGUI minutesText;
    [SerializeField] private TextMeshProUGUI secondText;

    [SerializeField] private Clock clock;

    private int twoDigitNumber = 10;

    public void MoveTime()
    {
        MoveHour();
        MoveMinute();
        MoveSecond();
    }

    private void MoveHour()
    {
        if (clock.Hour < twoDigitNumber)
        {
            hourText.text = "0" + clock.Hour.ToString();
        }
        else
        {
            hourText.text = clock.Hour.ToString();
        } 
    }

    private void MoveMinute()
    {
        if (clock.Minute < twoDigitNumber)
        { 
            minutesText.text = "0" + clock.Minute.ToString(); 
        }
        
        else
        {
            minutesText.text = clock.Minute.ToString();
        }
    }

    private void MoveSecond()
    {
        if (clock.Second < twoDigitNumber)
        {
            secondText.text = "0" + clock.Second.ToString();
        }
        else
        {
            secondText.text = clock.Second.ToString();
        }
           
    }
}
