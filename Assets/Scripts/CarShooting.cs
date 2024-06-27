using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

public class CarShooting : MonoBehaviour
{
    public float turnSpeed = 15;
    public Transform firePoint;
    Camera mainCamera;

    // Raycast.
    RaycastWeapon weapon;

    private void Start()
    {
        mainCamera = Camera.main;
        weapon = GetComponentInChildren<RaycastWeapon>();
    }

    private void FixedUpdate()
    {
        // Aiming.
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        //float yCamera = mainCamera.transform.rotation.eulerAngles.y;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Vector3 direction = pointToLook - transform.position;
            direction.y = 0;

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.fixedDeltaTime);
        }

        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yCamera, 0), turnSpeed * Time.fixedDeltaTime);
    }

    private void LateUpdate()
    {
        // Shooting.
        if (Input.GetButtonDown("Fire1"))
        {
            weapon.StartFiring(firePoint.position, firePoint.forward);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            weapon.StopFiring();
        }
    }
}
