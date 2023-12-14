using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    public LineRenderer laserLine;
    public Transform staffTip; // Reference to the empty GameObject representing the staff tip
    private float xRotation = 0f;

    public float xSensitivity = 30f;
    public float ySensitivity = 30f;

    void Start()
    {
        // Lock the cursor to the center of the screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        xRotation -= mouseY * ySensitivity * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * (mouseX * xSensitivity * Time.deltaTime));

        // Call the method to handle the laser
        HandleLaser();
    }

    void HandleLaser()
    {
        Vector3 forward = cam.transform.forward;
        Vector3 laserStart = staffTip.position;
        Ray ray = new Ray(laserStart, forward);
        RaycastHit hit;
        Vector3 laserEnd = ray.GetPoint(100f);

        if (Input.GetMouseButton(0))
        {
            // If left mouse button is clicked, show the laser
            laserLine.gameObject.SetActive(true);

            if (Physics.Raycast(ray, out hit, 100f))
            {
                laserEnd = hit.point;
            }

            laserLine.SetPosition(0, laserStart);
            laserLine.SetPosition(1, laserEnd);
        }
        else
        {
            // If left mouse button is not clicked, hide the laser
            laserLine.gameObject.SetActive(false);
        }
    }
}