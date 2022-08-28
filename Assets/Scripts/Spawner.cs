using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private float _delay;

    private SpawnPoint[] _spawnPoints;
    List<Transform> _spawnPositions;

    private void Start()
    {
        _spawnPositions = new List<Transform>();
        _spawnPoints = gameObject.GetComponentsInChildren<SpawnPoint>();

        for(int i = 0; i < _spawnPoints.Length; i++)
        {
            _spawnPositions.Add(_spawnPoints[i].transform);
        }

        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        int i = 0;
        WaitForSeconds wait = new WaitForSeconds(_delay);

        for(; ; )
        {
            Instantiate(_enemy, _spawnPositions[i].position, _spawnPositions[i].rotation);

            if(i + 1 == _spawnPositions.Count)
                i = 0;
            else
                i++;

            yield return wait;
        }
    }
}