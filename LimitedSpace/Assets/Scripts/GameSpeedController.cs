using UnityEngine;

public class GameSpeedController : MonoBehaviour
{
    private void OnEnable()
    {
        GlobalEvents.OnGameOver += OnGameOver;
    }

    private void OnDisable()
    {
        GlobalEvents.OnGameOver -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 1.0f;
    }

    private void Update()
    {
        if (!_enabled)
        {
            return;
        }

        Time.timeScale += Time.deltaTime * _speedIncreaseRate;
    }

    private void OnGameOver()
    {
        _enabled = false;
    }

    [SerializeField] private float _speedIncreaseRate = 0.015f;

    private bool _enabled = true;
}
