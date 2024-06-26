using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CarShooting : MonoBehaviour
{
    RaycastWeapon weapon;

    private void Start()
    {
        weapon = GetComponentInChildren<RaycastWeapon>();
    }

    private void LateUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            weapon.StartFiring();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            weapon.StopFiring();
        }
    }
}
