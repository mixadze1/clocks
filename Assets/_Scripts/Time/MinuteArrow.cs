using UnityEngine;

public class MinuteArrow : MonoBehaviour
{
    [SerializeField] private Transform objectMin;
    [SerializeField] private Clock realTime;

    private float eulerMinutes = 6;

    public  void MoveTime()
    {
        objectMin.rotation = Quaternion.Euler(0, 0, -realTime.Minute * eulerMinutes);
    }   
}
