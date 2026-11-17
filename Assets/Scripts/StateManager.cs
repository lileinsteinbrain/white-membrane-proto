using UnityEngine;
using System;

public enum AppState { Idle, Face1, Face2, Abstract }

public class StateManager : MonoBehaviour
{
    // Global singleton
    public static StateManager I { get; private set; }

    // Current state
    public AppState CurrentState { get; private set; } = AppState.Idle;

    // State change event (subscribed to by the HUD and material controller)
    public event Action<AppState> OnStateChanged;

    void Awake()
    {
        I = this;
        DontDestroyOnLoad(gameObject); // optional: persist across scenes
    }

    public void SetState(AppState s)
    {
        if (s == CurrentState) return;
        CurrentState = s;
        OnStateChanged?.Invoke(CurrentState);
    }
}