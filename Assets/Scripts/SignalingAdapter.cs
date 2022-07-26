using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SignalingAdapter : MonoBehaviour
{
    [SerializeField] private float _maxVolume;
    [SerializeField] private float _step;

    private AudioSource _audio;
    private Coroutine _makeLouder;
    private Coroutine _makeQuieter;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void PlaySignal()
    {
        StopCoroutine(MakeLouder());
        StopCoroutine(MakeQuieter());
        StartCoroutine(MakeLouder());
    }

    public void StopSignal()
    {
        StopCoroutine(MakeQuieter());
        StopCoroutine(MakeLouder());
        StartCoroutine(MakeQuieter());
    }

    private IEnumerator MakeLouder()
    {
        while(_audio.volume <= _maxVolume)
        {
            _audio.volume += _step;

            yield return null;
        }
    }

    private IEnumerator MakeQuieter()
    {
        while(_audio.volume >= 0)
        {
            _audio.volume -= _step;

            yield return null;
        }
    }
}