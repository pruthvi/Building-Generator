using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    float horizontalSpeed = 5.0f;
    float verticalSpeed = 2.0f;

    void Update()
    {
        // Get the mouse delta. This is not in the range -1...1

        if (Input.GetMouseButton(0))
        {
            float h = horizontalSpeed * Input.GetAxis("Mouse X");
            float v = verticalSpeed * Input.GetAxis("Mouse Y");

            transform.Rotate(0, h, 0);
        }

    }



}
