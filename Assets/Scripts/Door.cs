using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private float _closedAngle;
    [SerializeField] private float _openedAngle;

    [SerializeField] private float _doorLerp = 10f;

    [field: SerializeField] public bool Opened { get; set; }

    private float _angle;

    void Update()
    {
        _angle = Mathf.Lerp(_angle, Opened ? _openedAngle : _closedAngle, Time.deltaTime * _doorLerp);

        transform.localEulerAngles = new Vector3(0, _angle, 0);
    }
}
