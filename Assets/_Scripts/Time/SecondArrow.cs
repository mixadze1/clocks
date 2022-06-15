using UnityEngine;

public class SecondArrow : MonoBehaviour
{
    [SerializeField] private Transform objectSecond;
    [SerializeField] private Clock realTime;

    private float eulerSecond = 6;

    public void MoveTime()
    {
        objectSecond.rotation = Quaternion.Euler(0, 0, -realTime.Second * eulerSecond);
    }
}

