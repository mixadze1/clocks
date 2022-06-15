using UnityEngine;

public class HourArrow : MonoBehaviour
{
    [SerializeField] private Transform objectHour;
    [SerializeField] private Clock realTime;
    private float eulerHour = 30;

    public void MoveTime()
    {
        objectHour.rotation = Quaternion.Euler(0, 0, -realTime.Hour * eulerHour);
    }
}
