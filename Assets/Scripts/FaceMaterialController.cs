using UnityEngine;

public class FaceMaterialController : MonoBehaviour
{
    [Header("Refs")]
    [SerializeField] private StateManager stateManager;
    [SerializeField] private Renderer faceMesh;  // any plain Renderer works for now, e.g. a sphere

    [Header("Materials (Idle, Face1, Face2, Abstract)")]
    [SerializeField] private Material idleMat;
    [SerializeField] private Material face1Mat;
    [SerializeField] private Material face2Mat;
    [SerializeField] private Material abstractMat;

    void Awake()
    {
        // Find StateManager automatically (in case it was not assigned)
        if (stateManager == null) stateManager = FindObjectOfType<StateManager>();

        // Find faceMesh automatically: prefer the assigned one, otherwise use the Renderer on this object
        if (faceMesh == null) faceMesh = GetComponent<Renderer>();
    }

    void OnEnable()
    {
        if (stateManager != null)
        {
            stateManager.OnStateChanged += HandleState;
            HandleState(stateManager.CurrentState); // initialise once
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
        // sharedMaterial changes the appearance without instantiating a clone; fine for this demo
        faceMesh.sharedMaterial = m;
    }
}