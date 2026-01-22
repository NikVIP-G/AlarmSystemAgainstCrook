using UnityEngine;

public class Home : MonoBehaviour 
{
    [SerializeField] private AlarmSystem _alarmSystem;
    [SerializeField] private DoorTrigger _trigger;

    private void OnEnable()
    {
        _trigger.OpenedCrook += Work;
    }

    private void OnDisable()
    {
        _trigger.OpenedCrook -= Work;
    }

    private void Work()
    {
        _alarmSystem.Handler();
    }
}