using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SignalingController : MonoBehaviour
{
    [SerializeField] private float _maxVolume;
    [SerializeField] private float _step;

    private AudioSource _audio;
    private Coroutine _changeVolumeCoroutine;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void PlaySignal()
    {
        if( _changeVolumeCoroutine != null)
            StopCoroutine( _changeVolumeCoroutine );

        _changeVolumeCoroutine = StartCoroutine(ChangeVolumeSignal(_maxVolume, _step));
    }

    public void StopSignal()
    {
        if (_changeVolumeCoroutine != null)
            StopCoroutine(_changeVolumeCoroutine);

        _changeVolumeCoroutine = StartCoroutine(ChangeVolumeSignal(0, _step));
    }

    private IEnumerator ChangeVolumeSignal(float target, float step)
    {
        while(_audio.volume != target)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, target, step);

            yield return null;
        }
    }
}