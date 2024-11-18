using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager _inst;

    [SerializeField]
    private float _sensitivity = 5.0f;

    [SerializeField]
    private float _positionLerp = 10f;

    private float _rotateX, _rotateY;

    private Transform _pivot;

    void Awake()
    {
        _inst = this;
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            _rotateX += Input.GetAxis("Mouse Y") * _sensitivity;
            _rotateY -= Input.GetAxis("Mouse X") * _sensitivity;

            transform.eulerAngles = new Vector3(_rotateX, _rotateY, 0);
        }

        transform.position = Vector3.Lerp(transform.position, _pivot.position, Time.deltaTime*_positionLerp);
    }

    public void SetPivot(Transform pivot)
    {
        _pivot = pivot;
        // transform.position = pivot.position;
    }
}
