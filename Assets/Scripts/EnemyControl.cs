using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public int healthPoints;
    //private WinOrLoose condition;

    private void Start()
    {
        healthPoints = 100;
        //condition = FindObjectOfType<WinOrLoose>();
    }

    // Funci�n de da�o.
    public void receiveDamage()
    {
        healthPoints = healthPoints - 50;

        if (healthPoints <= 0)
        {
            this.botDeath();
        }
    }

    public void botDeath()
    {
        Destroy(gameObject);

        //condition.EnemyEliminated();
    }

    // Da�o por colisi�n del proyectil.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            receiveDamage();
        }
    }

}
