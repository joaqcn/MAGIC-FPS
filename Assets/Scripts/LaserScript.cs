using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public GameObject laserPrefab;
    public Camera mainCamera;

    // Update is called once per frame
    void Update()
    {
        

        Aim();
    }

    void Shoot()
    {
        laserPrefab.SetActive(true);

       
    }

    void StopShooting()
    {
        laserPrefab.SetActive(false);
    }

    void Aim()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if (Input.GetMouseButtonUp(0))
        {
            StopShooting();
        }
        if (Input.GetMouseButton(1))
        {
            mainCamera.fieldOfView = 40;
        }
        else
        {
            mainCamera.fieldOfView = 60;
        }
    }
}