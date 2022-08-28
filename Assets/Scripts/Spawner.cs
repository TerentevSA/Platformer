using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private float _delay;

    private SpawnPoint[] _spawnPoints;

    private void Start()
    {
        _spawnPoints = gameObject.GetComponentsInChildren<SpawnPoint>();

        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        int i = 0;
        WaitForSeconds wait = new WaitForSeconds(_delay);

        for(; ; )
        {
            Instantiate(_enemy, _spawnPoints[i].transform.position, _spawnPoints[i].transform.rotation);

            if(i + 1 == _spawnPoints.Length)
                i = 0;
            else
                i++;

            yield return wait;
        }
    }
}