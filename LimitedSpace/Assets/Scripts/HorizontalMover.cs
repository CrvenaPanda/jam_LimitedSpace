using UnityEngine;

public class HorizontalMover : MonoBehaviour
{
    private void Update()
    {
        this.transform.position += Vector3.right * _speed * Time.deltaTime;
    }

    [SerializeField] private float _speed = 5.0f;
}
