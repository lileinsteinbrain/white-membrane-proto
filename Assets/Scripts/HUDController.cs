using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stateText;
    [SerializeField] private StateManager stateManager;

    void Awake()
    {
        if (stateManager == null) stateManager = FindObjectOfType<StateManager>();
    }

    void OnEnable()
    {
        if (stateManager != null)
        {
            stateManager.OnStateChanged += HandleStateChanged;
            UpdateText(stateManager.CurrentState);
        }
    }

    void OnDisable()
    {
        if (stateManager != null)
            stateManager.OnStateChanged -= HandleStateChanged;
    }

    private void HandleStateChanged(AppState s) => UpdateText(s);
    private void UpdateText(AppState s)
    {
        if (stateText != null) stateText.text = s.ToString();
    }
}