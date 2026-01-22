using System;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private Door _door;

    public event Action OpenedCrook;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Crook>(out Crook crook))
        {
            _door.Open();
            OpenedCrook?.Invoke();
        }
    }
}
