using UnityEngine;

public class ArrowHour : MonoBehaviour
{
    [SerializeField] private Transform _objectHour;
    [SerializeField] private Clock _realTime;
    private float _eulerHour = 30;

    public void MoveTime()
    {
        _objectHour.rotation = Quaternion.Euler(0, 0, -_realTime.Hour * _eulerHour);
    }
}
