using System;

public class GlobalEvents
{
    public static event Action OnStart;
    public static event Action OnUpdateScoreText;
    public static event Action OnGameOver;

    public static void Start()
    {
        OnStart?.Invoke();
    }

    public static void UpdateScoreText()
    {
        OnUpdateScoreText?.Invoke();
    }

    public static void GameOver()
    {
        OnGameOver?.Invoke();
    }
}
