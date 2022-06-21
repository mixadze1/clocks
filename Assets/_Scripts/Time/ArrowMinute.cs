using UnityEngine;

public class ArrowMinute : MonoBehaviour
{
    [SerializeField] private Transform _objectMin;
    [SerializeField] private Clock _realTime;

    private float _eulerMinutes = 6;

    public  void MoveTime()
    {
        _objectMin.rotation = Quaternion.Euler(0, 0, -_realTime.Minute * _eulerMinutes);
    }   
}
