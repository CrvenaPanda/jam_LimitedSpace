using System;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEvents
{
    public static event Action OnStart;

    public static void Start()
    {
        OnStart?.Invoke();
    }
}
