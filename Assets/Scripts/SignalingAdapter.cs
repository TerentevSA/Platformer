using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SignalingAdapter : MonoBehaviour
{
    [SerializeField] private float _maxVolume;
    [SerializeField] private float _step;

    private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void PlaySignal() => MakeLouder();
    public void StopSignal() => MakeQuieter();

    private IEnumerable MakeLouder()
    {
        while(_audio.volume < _maxVolume)
        {
            _audio.volume += _step;

            yield return null;
        }
    }

    private IEnumerable MakeQuieter()
    {
        while(_audio.volume > 0)
        {
            _audio.volume -= _step;

            yield return null;
        }
    }
}