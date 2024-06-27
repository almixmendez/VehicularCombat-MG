using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWeapon : MonoBehaviour
{
    //public bool isFiring = false;
    //public ParticleSystem[] muzzleFlash;
    //public ParticleSystem hitEffect;
    //public Transform raycastOrigin;
    //public Transform raycastDestination;

<<<<<<< HEAD
    Ray ray;
    RaycastHit hitInfo;
    Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    public void StartFiring(Vector3 firePosition, Vector3 fireDirection)
    {
        isFiring = true;
        foreach (var particle in muzzleFlash)
        {
            particle.Emit(1);
        }

        ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        ray.origin = raycastOrigin.position;
        ray.direction = raycastDestination.position - raycastOrigin.position;

        if (Physics.Raycast(ray, out hitInfo))
        {
            //Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 1.0f);
            hitEffect.transform.position = hitInfo.point;
            hitEffect.transform.forward = hitInfo.normal;
            hitEffect.Emit(1);
        }
    }
=======
    //Ray ray;
    //RaycastHit hitInfo;

    //public void StartFiring()
    //{
    //    isFiring = true;
    //    foreach (var particle in muzzleFlash)
    //    {
    //        particle.Emit(1);
    //    }

    //    ray.origin = raycastOrigin.position;
    //    ray.direction = raycastDestination.position - raycastOrigin.position;
    //    if(Physics.Raycast(ray, out hitInfo))
    //    {
    //        //Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 1.0f);
    //        hitEffect.transform.position = hitInfo.point;
    //        hitEffect.transform.forward = hitInfo.normal;
    //        hitEffect.Emit(1);
    //    }
    //}
>>>>>>> ed4745c412fd7687d5ed3950ff8644b2e45531bf

    //public void StopFiring()
    //{
    //    isFiring = false;
    //}
}
