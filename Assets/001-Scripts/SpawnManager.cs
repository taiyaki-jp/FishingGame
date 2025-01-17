using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _spawnPoints;
    private List<GameObject> _usedPoint = new List<GameObject>();
    [SerializeField] private GameObject _fishPrefab;

    private void Start()
    {
        Spawn();
    }


    private void Spawn()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject point = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
            Instantiate(_fishPrefab, point.transform.position, Quaternion.identity);
            _usedPoint.Add(point);
            _spawnPoints.Remove(point);
        }
        _spawnPoints.AddRange(_usedPoint);
        _usedPoint.Clear();
    }
}
