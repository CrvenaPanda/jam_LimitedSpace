using System.Collections.Generic;
using UnityEngine;

public class EnvController : MonoBehaviour
{
    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer < 0.0f)
        {
            CreateObject();
            _timer = 0.5f;
        }
    }

    private void CreateObject()
    {
        float zPos = Random.Range(_verSpawnRange.x, _verSpawnRange.y);

        int index = Random.Range(0, _envPrefabs.Count);
        var envObject = Instantiate(_envPrefabs[index]);
        envObject.transform.position = new Vector3(
            this.transform.position.x,
            envObject.transform.position.y,
            zPos
            );
    }


    [SerializeField] private List<GameObject> _envPrefabs;
    [SerializeField] private Vector2 _verSpawnRange;

    private float _timer = 0.5f;
}
