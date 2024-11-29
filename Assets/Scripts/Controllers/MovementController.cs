using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private LayerMask _pointLayer;
    [SerializeField] private LayerMask _targetLayer;

    [field: SerializeField] public MovementPoint CurrentPoint { get; private set; }
    public FocusTarget CurrentTarget { get; private set; }

    void Start()
    {
        ApproachPoint(CurrentPoint);
    }

    void Update()
    {
        if (InputHandler.GetMouseButtonDown(0))
        {
            if (CheckPointClick()) return;
            if (CheckTargetClick()) return;
        }

        // if (Input.GetKeyDown(KeyCode.Space) && CurrentArea.State != null)
        // {
        //     EnterArea();
        // }
    }

    private bool CheckPointClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out RaycastHit hit, float.PositiveInfinity, _pointLayer)) return false;

        var point = hit.collider.GetComponent<MovementPoint>();
        if (point == null) return false;

        LeavePoint();
        ApproachPoint(point);

        return true;
    }
    private bool CheckTargetClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out RaycastHit hit, float.PositiveInfinity, _targetLayer)) return false;

        var focusTarget = hit.collider.GetComponentInParent<FocusTarget>();
        if (focusTarget == null) return false;

        EnterTarget(focusTarget);

        return true;
    }

    private void LeavePoint()
    {
        CurrentPoint.gameObject.SetActive(true);

        foreach (var target in CurrentPoint.Targets)
        {
            target.SetActive(false);
        }
    }
    private void ApproachPoint(MovementPoint next)
    {
        CurrentPoint = next;
        CurrentPoint.gameObject.SetActive(false);

        CameraManager._inst.CurrentPivot = CurrentPoint.transform;

        foreach (var target in CurrentPoint.Targets)
        {
            target.SetActive(true);
        }

        // CameraManager._inst.CanRotate = true;
    }

    private void EnterTarget(FocusTarget next)
    {
        CurrentTarget = next;

        foreach (var target in CurrentPoint.Targets) target.SetActive(false);

        CameraManager._inst.CanRotate = false;
        CameraManager._inst.CurrentPivot = next.Pivot;
        StateManager._inst.ChangeState(next.State);

        CameraManager._inst.InteractionDistance = next.InteractionDistance;

        next.OnEnter.Invoke();
    }

    public void ExitTarget()
    {
        foreach (var focusTarget in CurrentPoint.Targets) focusTarget.SetActive(true);

        CurrentTarget.OnExit.Invoke();
        
        StateManager._inst.ChangeState<MovementController>();
        CameraManager._inst.CanRotate = true;
        ApproachPoint(CurrentPoint);

        CurrentTarget = null;
    }
}
