using UnityEngine;

public class CameraController : MonoBehaviour
{
    private void Start()
    {
        _offsetFromTarget = this.transform.position - _target.position;
    }

    private void Update()
    {
        this.transform.position = _target.position + _offsetFromTarget;
    }

    [SerializeField] private Transform _target;

    private Vector3 _offsetFromTarget;
}
