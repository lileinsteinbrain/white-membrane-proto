using UnityEngine;

public class FaceMaterialController : MonoBehaviour
{
    [Header("Refs")]
    [SerializeField] private StateManager stateManager;
    [SerializeField] private Renderer faceMesh;  // 我们现在只需要一个普通 Renderer，比如小球

    [Header("Materials (Idle, Face1, Face2, Abstract)")]
    [SerializeField] private Material idleMat;
    [SerializeField] private Material face1Mat;
    [SerializeField] private Material face2Mat;
    [SerializeField] private Material abstractMat;

    void Awake()
    {
        // 自动找 StateManager（防止忘拖）
        if (stateManager == null) stateManager = FindObjectOfType<StateManager>();

        // 自动找 faceMesh：优先用你手动拖的；否则在我自己身上找 Renderer
        if (faceMesh == null) faceMesh = GetComponent<Renderer>();
    }

    void OnEnable()
    {
        if (stateManager != null)
        {
            stateManager.OnStateChanged += HandleState;
            HandleState(stateManager.CurrentState); // 初始化一次
        }
    }

    void OnDisable()
    {
        if (stateManager != null)
        {
            stateManager.OnStateChanged -= HandleState;
        }
    }

    private void HandleState(AppState s)
    {
        if (faceMesh == null) return;

        switch (s)
        {
            case AppState.Idle:
                ApplyMat(idleMat);
                break;
            case AppState.Face1:
                ApplyMat(face1Mat);
                break;
            case AppState.Face2:
                ApplyMat(face2Mat);
                break;
            case AppState.Abstract:
                ApplyMat(abstractMat);
                break;
        }
    }

    void ApplyMat(Material m)
    {
        if (m == null) return;
        // sharedMaterial = 改的是“外观”，不会实例化一份clone，适合我们现在这种demo用
        faceMesh.sharedMaterial = m;
    }
}