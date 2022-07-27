using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SignalingAdapter : MonoBehaviour
{
    [SerializeField] private float _maxVolume;
    [SerializeField] private float _step;

    private AudioSource _audio;
    private Coroutine _makeLouderCoroutine;
    private Coroutine _makeQuieterCoroutine;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void PlaySignal()
    {
        StopSignalCoroutines();

        _makeLouderCoroutine = StartCoroutine(MakeLouder());
    }

    public void StopSignal()
    {
        StopSignalCoroutines();

        _makeQuieterCoroutine = StartCoroutine(MakeQuieter());
    }

    private void StopSignalCoroutines()
    {
        if (_makeLouderCoroutine != null)
            StopCoroutine(_makeLouderCoroutine);

        if (_makeQuieterCoroutine != null)
            StopCoroutine(_makeQuieterCoroutine);
    }

    private IEnumerator MakeLouder()
    {
        while (_audio.volume <= _maxVolume)
        {
            _audio.volume += _step;

            yield return null;
        }
    }

    private IEnumerator MakeQuieter()
    {
        while (_audio.volume >= 0)
        {
            _audio.volume -= _step;

            yield return null;
        }
    }
}