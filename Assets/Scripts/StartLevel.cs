using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class StartLevel : MonoBehaviour
{
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _targetColor;
    [SerializeField] private float _duration;

    private SpriteRenderer _renderer;
    private float _time;
    private float _normalizeTime;

    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _time += Time.deltaTime;
        _normalizeTime = _time / _duration;

        if (_normalizeTime <= _duration)
        {
            _renderer.color = Color.Lerp(_startColor, _targetColor, _normalizeTime);
        }
    }
}