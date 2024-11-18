using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform[] _points;
    public int _target = 0;
    
    public float _positionLerp = 10f;
    public float _rotationLerp = 10f;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _points[_target].position, Time.deltaTime*_positionLerp);
        transform.rotation = Quaternion.Lerp(transform.rotation, _points[_target].rotation, Time.deltaTime*_rotationLerp);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            _target = (_target+1)%_points.Length;
        }
    }
}
