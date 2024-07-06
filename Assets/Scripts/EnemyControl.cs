using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public float healthPoints = 10;
    public float maxHealthPoints = 10;
    public float playerAttackCooldown = 10;
    private bool canPlayerAttack = true;

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
        if (collision.gameObject.CompareTag("Player") && canPlayerAttack)
        {
            receiveDamage(2f);
            StartCoroutine(PlayerAttackCooldown());
        }
        else if (collision.gameObject.CompareTag("Bullet") && canPlayerAttack)
        {
            receiveDamage(2f);
            StartCoroutine(PlayerAttackCooldown());
        }
    }

    private IEnumerator PlayerAttackCooldown()
    {
        canPlayerAttack = false;
        yield return new WaitForSeconds(playerAttackCooldown);
        canPlayerAttack = true;
    }
}