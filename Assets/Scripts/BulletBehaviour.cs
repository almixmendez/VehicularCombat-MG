using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody rb;
    public float force;
    public float damage = 1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Enemy enemyComponent = collision.gameObject.GetComponent<Enemy>();

        //if (enemyComponent != null)
        //{
        //    enemyComponent.TakeDamage(damage);
        //}

        //Destroy(gameObject);
    }
}
