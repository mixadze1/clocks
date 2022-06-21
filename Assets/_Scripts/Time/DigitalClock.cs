using TMPro;
using UnityEngine;

public class DigitalClock : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _hourText;
    [SerializeField] private TextMeshProUGUI _minutesText;
    [SerializeField] private TextMeshProUGUI _secondText;

    [SerializeField] private Clock _clock;

    private int _twoDigitNumber = 10;

    public void MoveTime()
    {
        MoveHour();
        MoveMinute();
        MoveSecond();
    }

    private void MoveHour()
    {
        if (_clock.Hour < _twoDigitNumber)
        {
            _hourText.text = "0" + _clock.Hour.ToString();
        }
        else
        {
            _hourText.text = _clock.Hour.ToString();
        } 
    }

    private void MoveMinute()
    {
        if (_clock.Minute < _twoDigitNumber)
        { 
            _minutesText.text = "0" + _clock.Minute.ToString(); 
        }
        
        else
        {
            _minutesText.text = _clock.Minute.ToString();
        }
    }

    private void MoveSecond()
    {
        if (_clock.Second < _twoDigitNumber)
        {
            _secondText.text = "0" + _clock.Second.ToString();
        }
        else
        {
            _secondText.text = _clock.Second.ToString();
        }
           
    }
}
