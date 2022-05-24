using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void Start()
    {
        UpdateDesiredZPos();
    }

    private void Update()
    {
        DetectVerticalMoving();
        MoveVertical();

        // TODO: Remove
        if (IsSprinting())
        {
            Run(_sprintSpeed * Time.deltaTime);
            return;
        }

        Run(_runSpeed * Time.deltaTime);
    }

    private void UpdateDesiredZPos()
    {
        _desiredZPos = GlobalData.zTrackPos[_trackIndex];
    }

    private bool IsSprinting()
    {
        return Input.GetKey(KeyCode.LeftShift);
    }

    private void Run(float speed)
    {
        this.transform.position += Vector3.right * speed;
    }

    private void DetectVerticalMoving()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            ChangeTrack(1);
            return;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            ChangeTrack(-1);
        }
    }

    private void ChangeTrack(int indexDelta)
    {
        _trackIndex += indexDelta;
        _trackIndex = Mathf.Clamp(_trackIndex, 0, 2);
        UpdateDesiredZPos();
    }

    private void MoveVertical()
    {
        if (IsEqual(this.transform.position.z, _desiredZPos, 0.02f))
        {
            return;
        }

        float direction = 1.0f;
        if (this.transform.position.z > _desiredZPos)
        {
            direction = -1.0f;
        }

        this.transform.position += Vector3.forward * _runSpeed * direction * Time.deltaTime;
    }

    bool IsEqual(float a, float b, float epsilon)
    {
        if (a >= b - epsilon && a <= b + epsilon)
        {
            return true;
        }

        return false;
    }

    [SerializeField] private float _runSpeed = 10f;
    [SerializeField] private float _sprintSpeed = 15f;
    [SerializeField] private float _upDownSpeed = 7.5f;

    private int _trackIndex = 1;
    private float _desiredZPos;
}
