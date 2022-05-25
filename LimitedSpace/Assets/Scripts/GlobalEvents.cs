using System;

public class GlobalEvents
{
    public static event Action OnStart;
    public static event Action OnUpdateScoreText;

    public static void Start()
    {
        OnStart?.Invoke();
    }

    public static void UpdateScoreText()
    {
        OnUpdateScoreText?.Invoke();
    }
}
