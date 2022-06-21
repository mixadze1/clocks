using UnityEngine;

public class SecondArrow : MonoBehaviour
{
    [SerializeField] private Transform _objectSecond;
    [SerializeField] private Clock _realTime;

    private float _eulerSecond = 6;

    public void MoveTime()
    {
        _objectSecond.rotation = Quaternion.Euler(0, 0, -_realTime.Second * _eulerSecond);
    }
}

