using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDebugAxis : MonoBehaviour
{
    private float _axisSize = 2;

    void Update()
    {
        DrawAxis();
    }

    private void DrawAxis()
    {
        Debug.DrawRay(transform.position, transform.forward * _axisSize, Color.blue);
        Debug.DrawRay(transform.position, transform.up * _axisSize, Color.green);
        Debug.DrawRay(transform.position, transform.right * _axisSize, Color.red);  
    }
}
