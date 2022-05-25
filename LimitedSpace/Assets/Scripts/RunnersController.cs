using System.Collections.Generic;
using UnityEngine;

public class RunnersController : MonoBehaviour
{
    private void Start()
    {
        _nextSpawnPos = _firstSpawnPos;
        _runners = new Queue<GameObject>();
    }

    private void Update()
    {
        if (_nextSpawnPos < _camera.position.x)
        {
            SpawnRunners();
            _nextSpawnPos += _distanceBetweenSpawns;
        }
    }

    private void SpawnRunners()
    {
        var formation = GetRandomFormation();
        for (int i = 0; i < formation.Length; i++)
        {
            if (formation[i] == 0)
            {
                continue;
            }

            var pos = new Vector3(_nextSpawnPos + _spawnLenghtFromCamera, 0.0f, GlobalData.zTrackPos[i]);
            SpawnRunner(pos);
        }
    }

    private int[] GetRandomFormation()
    {
        int formationIndex = _prevFormationIndex;
        while (formationIndex == _prevFormationIndex)
        {
            formationIndex = Random.Range(0, GlobalData.racersFormations.Count);
        }

        return GlobalData.racersFormations[formationIndex];
    }

    private void SpawnRunner(Vector3 pos)
    {
        if (_runners.Count > _maxRunners)
        {
            var runner = _runners.Dequeue();
            Destroy(runner);
        }

        var runnerInstance = Instantiate(_runnerPrefab, this.transform);
        runnerInstance.transform.position = pos;

        _runners.Enqueue(runnerInstance);
    }

    [SerializeField] private Transform _camera;
    [SerializeField] private GameObject _runnerPrefab;

    [SerializeField] private float _spawnLenghtFromCamera = 10.0f;
    [SerializeField] private float _distanceBetweenSpawns = 10.0f;
    [SerializeField] private float _firstSpawnPos = 10.0f;

    [SerializeField] private int _maxRunners = 12;

    private Queue<GameObject> _runners;

    private float _nextSpawnPos;
    private int _prevFormationIndex = -1;
}
