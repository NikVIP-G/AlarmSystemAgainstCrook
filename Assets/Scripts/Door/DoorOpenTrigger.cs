using System;
using UnityEngine;

public class DoorOpenTrigger : MonoBehaviour
{
    [SerializeField] private Door _door;

    public event Action<bool> OpenedCrook;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<DoorOpener>(out DoorOpener doorOpener))
        {
            _door.Open();

            if (doorOpener.TryGetComponent<Crook>(out Crook crook))
            {
                if (crook.IsEntered)
                    crook.Disable();
                else
                    crook.Activite();

                OpenedCrook?.Invoke(crook.IsEntered);
            }
        }
    }
}
