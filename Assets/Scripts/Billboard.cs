using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public bool Flat = false;

    void Update()
    {
        if(!Flat)
            transform.LookAt(Camera.main.transform);
        else transform.forward = Camera.main.transform.forward;
    }
}
