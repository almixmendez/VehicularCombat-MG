using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float turnSpeed = 90f;

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.GetComponent<ObstacleScript>() != null)
        //{
        //    Destroy(gameObject);
        //    return;
        //}

        if (other.gameObject.name != "Player")
        {
            return;
        }

        //GameManager.inst.IncrementScore();

        Destroy(gameObject);
    }

    void Start()
    {

    }

    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
