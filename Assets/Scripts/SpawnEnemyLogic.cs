using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyLogic : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private float _timeToSpawn;

    private GameObject[] _spawnPoints;
    private string _spawnPointTag = "SpawnPoint";

    private void Start()
    {
        _spawnPoints = GameObject.FindGameObjectsWithTag(_spawnPointTag);
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        int i = 0;

        for(; ; )
        {
            Instantiate(_enemy, _spawnPoints[i].transform.position, _spawnPoints[i].transform.rotation);

            if(i + 1 == _spawnPoints.Length)
                i = 0;
            else
                i++;

            yield return new WaitForSeconds( _timeToSpawn );
        }
    }
}