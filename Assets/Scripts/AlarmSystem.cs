using System.Collections;
using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private DoorOpenTrigger _door;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _delta = 0.2f;
    [SerializeField] private float _delay = 0.5f;

    private Coroutine _coroutine;
    private float _minVolume = 0f;
    private float _maxVolume = 1f;

    private void Awake()
    {
        _audioSource.volume = _minVolume;
    }

    private void OnEnable()
    {
        _door.OpenedCrook += Handler;
    }

    private void OnDisable()
    {
        _door.OpenedCrook -= Handler;
    }

    private void Handler(bool isEnteredCrook)
    {
        Stop();

        _coroutine = StartCoroutine(Warning(isEnteredCrook));
    }

    private IEnumerator Warning(bool isEnteredCrook)
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);
        float target = isEnteredCrook ? _maxVolume : _minVolume;

        while (Mathf.Approximately(_audioSource.volume, target) == false)
        {
            yield return wait;
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, _delta);
        }
    }

    private void Stop()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }
}
