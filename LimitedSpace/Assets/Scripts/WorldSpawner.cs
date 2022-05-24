using System.Collections.Generic;
using UnityEngine;

public class WorldSpawner : MonoBehaviour
{
    private void Start()
    {
        _nextPointX = -_groundLenght;
        _instances = new Queue<GameObject>(_maxInstances);
    }

    private void Update()
    {
        if (_world.GetCameraTransform().position.x > (_nextPointX - _groundLenght))
        {
            SpawnGround();
            _nextPointX += _groundLenght;
        }
    }

    private void SpawnGround()
    {
        var instance = Instantiate(_prefab, this.transform);
        instance.transform.position = new Vector3(
            _nextPointX,
            instance.transform.position.y,
            instance.transform.position.z
            );

        AddInstance(instance);
    }

    private void AddInstance(GameObject instance)
    {
        _instances.Enqueue(instance);
        if (_instances.Count > _maxInstances)
        {
            Destroy(_instances.Dequeue());
        }
    }


    [SerializeField] private WorldController _world;
    [SerializeField] private GameObject _prefab;

    [SerializeField] private int _maxInstances = 3;
    [SerializeField] private float _groundLenght;

    private Queue<GameObject> _instances;
    private float _nextPointX;
}
