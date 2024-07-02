using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float turnSpeed = 90f;
    private GameManager gameManager;
    private Rigidbody collectibleRb;

    private void Start()
    {
        collectibleRb = GetComponent<Rigidbody>();
        collectibleRb.isKinematic = true;

        gameManager = GameManager.inst;
        if (gameManager == null)
        {
            Debug.Log("GameManager no encontrado!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Colisioné!");
            gameManager.IncrementScore();
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
