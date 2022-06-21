using UnityEngine;

public class MinuteArrow : MonoBehaviour
{
    [SerializeField] private Transform _objectMin;
    [SerializeField] private Clock _realTime;

    private float _eulerMinutes = 6;

    public  void MoveTime()
    {
        _objectMin.rotation = Quaternion.Euler(0, 0, -_realTime.Minute * _eulerMinutes);
    }   
}
