using System.Collections.Generic;
using UnityEngine;

public class ObjectsSpawner : MonoBehaviour
{
    private void Start()
    {
        SpawnObjects();
    }

    private void SpawnObjects()
    {
        var realXRange = _xRange + new Vector2(transform.position.x, transform.position.x);
        var realZRange = _zRange + new Vector2(transform.position.z, transform.position.z);

        for (int i = 0; i < _amount; i++)
        {
            SpawnObject(GetRandomPos(realXRange, realZRange));
        }
    }

    private void SpawnObject(Vector3 position)
    {
        int index = Random.Range(0, _objPrefabs.Count);

        var envObject = Instantiate(_objPrefabs[index], this.transform);
        envObject.transform.position = position;
        envObject.transform.localScale = Vector3.one * GetRandomScale();
        envObject.transform.eulerAngles = Vector3.up * GetRandomRotation();
    }

    private Vector3 GetRandomPos(Vector2 xRange, Vector2 zRange)
    {
        return new Vector3(Random.Range(xRange.x, xRange.y), 0.0f, Random.Range(zRange.x, zRange.y));
    }

    private float GetRandomRotation()
    {
        return Random.Range(_rotationRange.x, _rotationRange.y);
    }

    private float GetRandomScale()
    {
        return _scalesRange[Random.Range(0, _scalesRange.Count)];
    }

    [SerializeField] private List<GameObject> _objPrefabs;
    [SerializeField] private Vector2 _xRange = new Vector2(0.0f, 100.0f);
    [SerializeField] private Vector2 _zRange = new Vector2(5.0f, 80.0f);
    [SerializeField] private Vector2 _rotationRange = new Vector2(-20.0f, 5.0f);
    [SerializeField] private int _amount = 500;

    [SerializeField] private List<float> _scalesRange;
}
