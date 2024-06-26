using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.EventSystems;

public class CarShooting : MonoBehaviour
{
    #region VARIABLES
    private Camera cam;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
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
        weapon = GetComponentInChildren<RaycastWeapon>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

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
