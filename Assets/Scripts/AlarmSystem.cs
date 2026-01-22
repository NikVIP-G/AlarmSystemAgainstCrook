using System.Collections;
using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _delta = 0.2f;
    [SerializeField] private float _delay = 0.5f;

    private Coroutine _coroutine;
    private float _minVolume = 0f;
    private float _maxVolume = 1f;

    public bool IsWork { get; private set; } = false;

    public void Handler()
    {
        Stop();
        SetIsWork();
        float targetVolume = IsWork ? _maxVolume : _minVolume;
        _coroutine = StartCoroutine(Work(targetVolume));
    }

    private void Awake()
    {
        _audioSource.volume = _minVolume;
    }

    private IEnumerator Work(float targetVolume)
    {
        WaitForSeconds wait = new(_delay);

        while (Mathf.Approximately(_audioSource.volume, targetVolume) == false)
        {
            yield return wait;
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _delta);
        }

        if (_audioSource.volume == 0)
            _audioSource.Stop();
    }

    private void Stop()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private void SetIsWork()
    {
        if (IsWork)
            Disable();
        else
            Activate();
    }

    private void Activate()
    {
        IsWork = true;
    }

    private void Disable()
    {
        IsWork = false;
    }
}
