using System.Collections;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Threading;
=======
using UnityEditor.PackageManager;
>>>>>>> ed4745c412fd7687d5ed3950ff8644b2e45531bf
using UnityEngine;
using UnityEngine.EventSystems;

public class CarShooting : MonoBehaviour
{
<<<<<<< HEAD
    public float turnSpeed = 15;
    public Transform firePoint;
    Camera mainCamera;

    // Raycast.
=======
    #region VARIABLES
    private Camera cam;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
>>>>>>> ed4745c412fd7687d5ed3950ff8644b2e45531bf
    RaycastWeapon weapon;
    public float bulletForce = 15;
    public float damage = 1f;

    public bool isFiring = false;
    public ParticleSystem[] muzzleFlash;
    public ParticleSystem hitEffect;
    public Transform raycastOrigin;
    public Transform raycastDestination;

    Ray ray;
    RaycastHit hitInfo;
    #endregion

    private void Start()
    {
        mainCamera = Camera.main;
        weapon = GetComponentInChildren<RaycastWeapon>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

<<<<<<< HEAD
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
=======
    private void Update()
    {
        StartFiring();
        //// Weapon rotation (Aim)
        //Vector3 mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));
        //Vector3 direction = mousePos - transform.position;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle + 90f, Vector3.forward);

    }

    public void StartFiring()
    {
        
        // Shooting
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
>>>>>>> ed4745c412fd7687d5ed3950ff8644b2e45531bf
        }

        if (Input.GetMouseButton(0) && canFire)
        {

            foreach (var particle in muzzleFlash)
            {
                particle.Emit(1);
            }

            ray.origin = raycastOrigin.position;
            ray.direction = raycastDestination.position - raycastOrigin.position;
            if (Physics.Raycast(ray, out hitInfo))
            {
                //Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 1.0f);
                hitEffect.transform.position = hitInfo.point;
                hitEffect.transform.forward = hitInfo.normal;
                hitEffect.Emit(1);
            }

            
            GameObject bull = Instantiate(bullet, bulletTransform.position, Quaternion.identity);

            Rigidbody rb = bull.GetComponent<Rigidbody>();
            rb.AddRelativeForce(transform.forward * bulletForce, ForceMode.Impulse);
            Destroy(bull, 1.5f);
            canFire = false;

        }
    }

    public void StopFiring()
    {
        isFiring = false;
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
