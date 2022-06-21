using UnityEngine;

public class AlarmMenu : MonoBehaviour
{
    [SerializeField] private GameObject alarmMenu;
    [SerializeField] private GameObject alarm;
    [SerializeField] private GameObject accept;
    [SerializeField] private GameObject backToMenu;
    [SerializeField] private GameObject inCorrect;
    [SerializeField] private GameObject fieldButton;
    [SerializeField] private GameObject buttonButtn;
    [SerializeField] private GameObject alarmField;
    [SerializeField] private GameObject alarmButton;

    public void Alarm()
    {
        alarmMenu.SetActive(true);
    }

    public void AcceptAlerm()
    {
        accept.SetActive(false);
        alarmButton.SetActive(false);
        alarmField.SetActive(false);
        backToMenu.SetActive(false);
        alarmMenu.SetActive(false);
        fieldButton.SetActive(true);
        buttonButtn.SetActive(true);
        alarm.SetActive(true);  
    }

    public void BackToMenu()
    {
        accept.SetActive(false);
        alarmButton.SetActive(false);
        alarmField.SetActive(false);
        backToMenu.SetActive(false);
        fieldButton.SetActive(true);
        buttonButtn.SetActive(true);
    }

    public void Field()
    {   
        accept.SetActive(true);
        fieldButton.SetActive(false);
        buttonButtn.SetActive(false);
        alarmField.SetActive(true);
        backToMenu.SetActive(true);
    }

    public void Button()
    {
        accept.SetActive(true);
        fieldButton.SetActive(false);
        buttonButtn.SetActive(false);
        alarmButton.SetActive(true );
        backToMenu.SetActive(true);
    }

    public void BackToClock()
    {
        alarmMenu.SetActive(false);

    }

    public void InCorrect()
    {
        inCorrect.SetActive(false);
    }

    
}
