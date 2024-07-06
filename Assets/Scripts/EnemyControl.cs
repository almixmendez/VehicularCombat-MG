using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public float healthPoints = 10;
    public float maxHealthPoints = 10;

    private void Start()
    {
        healthPoints = maxHealthPoints;
        //condition = FindObjectOfType<WinOrLoose>();
    }

    // Función de daño.
    public void receiveDamage(float damage)
    {
        healthPoints -= damage;

        if (healthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Daño por colisión.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            receiveDamage(2f);
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            receiveDamage(2f);
        }
    }
}
