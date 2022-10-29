using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnInterval;
    [SerializeField] private GameObject _wallPrefab;
    [SerializeField] private Transform _spawnPosition;

    private bool _isShortWall = false;
    void Start()
    {
        StartCoroutine(SpawnNextWall());
    }

    private IEnumerator SpawnNextWall()
    {
        yield return new WaitForSeconds(_spawnInterval);


        Instantiate(_wallPrefab, _spawnPosition);
        _isShortWall = false;

        StartCoroutine(SpawnNextWall());
    }
}
