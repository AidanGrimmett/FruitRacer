using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float sensitivity;

    private float xRotation;
    private float yRotation;

    void FixedUpdate()
    {
        // Get the mouse movement values
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * -sensitivity;

        // Calculate the new rotation values based on the mouse movement
        xRotation += mouseY;
        yRotation += mouseX;

        // Limit the rotation range, prevents flippy wippy and also stops camera from going through the floor
        xRotation = Mathf.Clamp(xRotation, -20f, 50f);

        // Apply the new rotation to the object
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
