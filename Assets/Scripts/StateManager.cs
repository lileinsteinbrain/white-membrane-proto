using UnityEngine;
using System;

public enum AppState { Idle, Face1, Face2, Abstract }

public class StateManager : MonoBehaviour
{
    // 全局单例
    public static StateManager I { get; private set; }

    // 当前状态
    public AppState CurrentState { get; private set; } = AppState.Idle;

    // 状态变更事件（HUD / 材质控制脚本会订阅）
    public event Action<AppState> OnStateChanged;

    void Awake()
    {
        I = this;
        DontDestroyOnLoad(gameObject); // 可选：跨场景保留
    }

    public void SetState(AppState s)
    {
        if (s == CurrentState) return;
        CurrentState = s;
        OnStateChanged?.Invoke(CurrentState);
    }
}