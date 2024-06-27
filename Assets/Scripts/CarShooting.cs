using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.EventSystems;

public class CarShooting : MonoBehaviour
{
    #region VARIABLES
    public float turnSpeed = 15;
    public Transform firePoint;
    public GameObject bullet;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    public float bulletForce = 15f;
    public float damage = 1f;
    public ParticleSystem[] muzzleFlash;
    public ParticleSystem hitEffect;
    #endregion

    private void Start()
    {
        canFire = true;
    }

    //private void FixedUpdate()
    //{
    //    // Aiming.
    //    Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
    //    Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
    //    float rayLength;

    //    //float yCamera = mainCamera.transform.rotation.eulerAngles.y;

    //    if (groundPlane.Raycast(cameraRay, out rayLength))
    //    {
    //        Vector3 pointToLook = cameraRay.GetPoint(rayLength);
    //        Vector3 direction = pointToLook - transform.position;
    //        direction.y = 0;

    //        Quaternion targetRotation = Quaternion.LookRotation(direction);
    //        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.fixedDeltaTime);
    //    }

    //    //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yCamera, 0), turnSpeed * Time.fixedDeltaTime);
    //}

    private void LateUpdate()
    {
        // Shooting.
        if (Input.GetButtonDown("Fire1"))
        {
            StartFiring();
        }
    }

    private void Update()
    {
        FiringCooldown();
    }

    public void FiringCooldown()
    {
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }
    }

    public void StartFiring()
    {
        if (canFire)
        {

            foreach (var particle in muzzleFlash)
            {
                particle.Emit(1);
            }

            GameObject bull = Instantiate(bullet, firePoint.position, firePoint.rotation);
            Rigidbody rb = bull.GetComponent<Rigidbody>();

            rb.velocity = firePoint.forward * bulletForce;

            Destroy(bull, 1.5f);
            canFire = false;
        }
    }

    private void OnDrawGizmos()
    {
        if (firePoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(firePoint.position, firePoint.position + firePoint.forward * 2);
        }
    }
}
//private void LateUpdate()
//{
//    if (Input.GetButtonDown("Fire1"))
//    {
//        weapon.StartFiring();
//    }
//    if (Input.GetButtonUp("Fire1"))
//    {
//        weapon.StopFiring();
//    }
//}
