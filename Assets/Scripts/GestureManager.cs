using UnityEngine;

public class GestureManager : MonoBehaviour
{
    [SerializeField] private StateManager stateManager;

    private float lastTapTime = 0f;
    private const float DoubleTapWindow = 0.3f;

    void Awake()
    {
        if (stateManager == null)
            stateManager = FindObjectOfType<StateManager>();
    }

    void Update()
    {
        // 鼠标 (编辑器里点 Game 视图)
        if (Input.GetMouseButtonDown(0))
        {
            HandleTap();
        }

        // 触摸 (真机以后)
        if (Input.touchCount > 0)
        {
            var t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Ended)
                HandleTap();
        }
    }

    private void HandleTap()
    {
        float now = Time.time;

        if (now - lastTapTime < DoubleTapWindow)
        {
            // double tap -> 回 Idle
            stateManager?.SetState(AppState.Idle);
            lastTapTime = 0f;
        }
        else
        {
            // single tap -> 尝试切下一个
            lastTapTime = now;
            Invoke(nameof(SingleTapIfNoDouble), DoubleTapWindow + 0.02f);
        }
    }

    private void SingleTapIfNoDouble()
    {
        if (lastTapTime == 0f) return; // 说明已经被双击处理
        lastTapTime = 0f;

        if (stateManager == null) return;

        var next = stateManager.CurrentState switch
        {
            AppState.Idle     => AppState.Face1,
            AppState.Face1    => AppState.Face2,
            AppState.Face2    => AppState.Abstract,
            _                 => AppState.Idle
        };

        stateManager.SetState(next);
    }
}