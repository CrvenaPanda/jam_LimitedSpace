using System.Collections.Generic;
using UnityEngine;

public class EnvController : MonoBehaviour
{
    private void Start()
    {
        _instances = new Queue<GameObject>(_maxObjectsCount);
        _lastRandomZPos = _verSpawnRange.x;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer < 0.0f)
        {
            CreateObject();
            _timer = _secUntilSpawn;
        }
    }

    private void CreateObject()
    {
        if (_instances.Count > _maxObjectsCount)
        {
            Destroy(_instances.Dequeue());
        }

        float zPos = GetRandomZPos();
        int index = Random.Range(0, _envPrefabs.Count);

        var envObject = Instantiate(_envPrefabs[index], _objectsHolder);
        envObject.transform.position = new Vector3(
            _spawnPos.position.x,
            envObject.transform.position.y,
            zPos
            );

        envObject.transform.eulerAngles =  Vector3.up * GetRandomRotation();
        _instances.Enqueue(envObject);
    }

    private float GetRandomRotation()
    {
        return Random.Range(_randomRotationRange.x, _randomRotationRange.y);
    }

    private float GetRandomZPos()
    {
        // Random float but not too close to prev.
        float randomZPos;
        for (int i = 0; i < 5; i++)
        {
            randomZPos = Random.Range(_verSpawnRange.x, _verSpawnRange.y);
            if (Mathf.Abs(_lastRandomZPos - randomZPos) > _minDiffFromLastRandomZ)
            {
                continue;
            }

            _lastRandomZPos = randomZPos;
            return randomZPos;
        }

        return Random.Range(_verSpawnRange.x, _verSpawnRange.y);
    }


    [SerializeField] private List<GameObject> _envPrefabs;
    [SerializeField] private Vector2 _verSpawnRange;
    [SerializeField] private float _secUntilSpawn = 0.3f;
    [SerializeField] private int _maxObjectsCount = 100;
    [SerializeField] private float _minDiffFromLastRandomZ = 5.0f;
    [SerializeField] private Vector2 _randomRotationRange = new Vector2(-25.0f, 10.0f);

    [SerializeField] private Transform _spawnPos;
    [SerializeField] private Transform _objectsHolder;

    private float _timer = 0.0f;
    private float _lastRandomZPos;
    private Queue<GameObject> _instances;
}
