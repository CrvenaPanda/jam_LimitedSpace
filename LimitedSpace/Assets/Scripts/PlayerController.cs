using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void Update()
    {
        MoveUpOrDown(Input.GetAxis("Vertical") * Time.deltaTime * _upDownSpeed);
        if (IsSprinting())
        {
            Run(_sprintSpeed * Time.deltaTime);
            return;
        }

        Run(_runSpeed * Time.deltaTime);
    }

    private bool IsSprinting()
    {
        return Input.GetKey(KeyCode.LeftShift);
    }

    private void Run(float speed)
    {
        this.transform.position += Vector3.right * speed;
    }

    private void MoveUpOrDown(float speed)
    {
        this.transform.position += Vector3.forward * speed;
    }

    [SerializeField] private float _runSpeed = 10f;
    [SerializeField] private float _sprintSpeed = 15f;
    [SerializeField] private float _upDownSpeed = 7.5f;
}
