using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager _inst;

    [field: SerializeField] public Transform CurrentPivot { get; set; }

    [field: SerializeField] public bool CanRotate { get; set; }


    [SerializeField] private float _moveSensitivity = 5.0f;

    [SerializeField] private float _positionLerp = 10f, _rotationLerp = 10f;


    private float _cameraX, _cameraY;

    public float InteractionDistance { get; set; }


    void Awake()
    {
        _inst = this;
    }

    void Update()
    {
        // вращение камеры пользователем
        if (CanRotate)
        {
            if (InputHandler.GetMouseButton(1))
            {
                _cameraX += Input.GetAxisRaw("Mouse X") * _moveSensitivity * Time.deltaTime;
                _cameraY -= Input.GetAxisRaw("Mouse Y") * _moveSensitivity * Time.deltaTime;
            }

            transform.eulerAngles = new Vector3(_cameraY, _cameraX, 0f);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, CurrentPivot.rotation, Time.deltaTime*_rotationLerp);
            _cameraY = transform.eulerAngles.x;
            _cameraX = transform.eulerAngles.y;
        }

        // плавное движение камеры к целевой точке
        transform.position = Vector3.Lerp(transform.position, CurrentPivot.position, _positionLerp * Time.deltaTime);


        // if (_cameraMode == CameraMode.Orbit)
        // {
        //     _target.localPosition = -Vector3.forward * _zoom;
        //     transform.rotation = _starterRotation * Quaternion.Euler(_cameraY * 50f, _cameraX * 50f, 0f);
        // }
        // else
        // {
        //     _target.localPosition = -Vector3.forward * _zoom - Vector3.up * _cameraY;
        //     _target.localEulerAngles = new Vector3(0f, _cameraX, 0f) * 50f;
        // }

        // // интерполяция
        // float positionLerp = _transitionTimer < 0 ? _positionLerp : _positionLerp * _transitionLerpMult;
        // float rotationLerp = _transitionTimer < 0 ? _rotationLerp : _rotationLerp * _transitionLerpMult;

        // if (_cameraMode == CameraMode.Orbit && _transitionTimer < 0f)
        //     _camera.position = Vector3.Slerp(_camera.position, _target.position, Time.deltaTime * positionLerp);
        // else
        //     _camera.position = Vector3.Lerp(_camera.position, _target.position, Time.deltaTime * positionLerp);

        // // _camera.position = _cameraMode == CameraMode.Orbit ? Vector3.Slerp(_camera.position, _target.position, Time.deltaTime * positionLerp) : Vector3.Lerp(_camera.position, _target.position, Time.deltaTime * positionLerp);
        // _camera.rotation = Quaternion.Lerp(_camera.rotation, _target.rotation, Time.deltaTime * rotationLerp);

        // выбор области
        // if (CanPickArea && InputHandler.GetMouseButtonDown(0))
        // {
        //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //     if (!Physics.Raycast(ray, out RaycastHit hit, float.PositiveInfinity)) return;

        //     Area area = hit.collider.gameObject.GetComponent<Area>();

        //     if (area == null) return;

        //     SetArea(area);
        // }
    }

    // public void SetArea(Area area)
    // {
    //     CurrentArea.gameObject.SetActive(true);

    //     CurrentArea = area;
    //     SetPivot(area.Pivot);
    //     if (area.State != null) StateManager._inst.ChangeState(area.State);
    //     _cameraMode = area.CameraMode;

    //     CurrentArea.gameObject.SetActive(false);

    //     _cameraX = 0;
    //     _cameraY = 0;
    //     _zoom = (_minZoom + _maxZoom) / 2.0f;
    //     _target.localEulerAngles = Vector3.zero;
    //     _transitionTimer = _transitionTime;
    // }

    // public void ResetPivot()
    // {
    //     SetPivot(CurrentArea.Pivot);
    // }
}
