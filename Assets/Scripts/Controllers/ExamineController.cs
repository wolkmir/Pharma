using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamineController : MonoBehaviour
{
    [SerializeField]
    private Transform _pivot;

    private Vector3 _oldPosition;

    public GameObject pickable;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) StateManager._inst.ChangeState<TableController>();
    }

    void OnEnable()
    {
        _oldPosition = pickable.transform.position;
        pickable.transform.position = _pivot.position;

        CameraManager._inst.SetPivot(_pivot);
        CameraManager._inst.CanPickArea = false;
    }

    void OnDisable()
    {
        if (pickable != null)
        {
            pickable.transform.position = _oldPosition;
            pickable = null;
        }
    }
}
