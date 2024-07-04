using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public int healthPoints = 10;
    public int maxHealthPoints = 10;
    //private WinOrLoose condition;

    private void Start()
    {
        healthPoints = maxHealthPoints;
        //condition = FindObjectOfType<WinOrLoose>();
    }

    // Funci�n de da�o.
    public void receiveDamage()
    {
        healthPoints = healthPoints - 2;

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
        if (collision.gameObject.CompareTag("Player"))
        {
            receiveDamage();
        }
    }
}
