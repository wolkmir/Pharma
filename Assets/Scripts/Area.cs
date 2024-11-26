using UnityEngine;
using UnityEngine.Events;

public class Area : MonoBehaviour
{
    [field: SerializeField] public Transform Pivot { get; private set; }
    [field: SerializeField] public GameObject State { get; private set; }
    [field: SerializeField] public float InteractionDistance { get; private set; } = 2.0f;

    [field: SerializeField] public CameraManager.CameraMode CameraMode { get; private set; } = CameraManager.CameraMode.Orbit;

    [SerializeField] private UnityEvent _onEnter;
    [SerializeField] private UnityEvent _onExit;

    void OnEnable()
    {
        _onExit.Invoke();
    }

    void OnDisable()
    {
        _onEnter.Invoke();
    }
}