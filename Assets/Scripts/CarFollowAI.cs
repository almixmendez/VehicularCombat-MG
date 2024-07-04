using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class CarFollowAI : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float acceleration = 5f;
    [SerializeField] private float maxSpeed = 20f;
    [SerializeField] private float minDistance;
    [SerializeField] private Transform player;
    [SerializeField] private float damageAmount = 1f;
    [SerializeField] private float attackCooldown = 1f;
    [SerializeField] private float attackWaitingTime = 1f;

    private PlayerHealth playerHealth;
    private bool canAttack = true;
    private Rigidbody rb;

    private void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (canAttack)
        {
            Follow();
        }
    }

    private void Follow()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance > minDistance)
            {
                Vector3 direction = (player.position - transform.position).normalized;

                if (rb.velocity.magnitude < maxSpeed)
                {
                    rb.AddForce(direction * acceleration, ForceMode.Acceleration);
                }
                //transform.position += direction * speed * Time.deltaTime;
                transform.LookAt(player);
            }
            //if (Vector2.Distance(transform.position, player.position) > minDistance)
            //{
            //    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            //}
            else
            {
                if (canAttack)
                {
                    Attack();
                    StartCoroutine(AttackCooldown());
                }
            }
        }
    }

    private void Attack()
    {
        if (player != null)
        {
            //PlayerHealth playerHealth = GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageAmount);
        }
    }

    private IEnumerator AttackCooldown()
    {
        canAttack = false;

        rb.velocity = Vector3.zero;
        yield return new WaitForSeconds(attackWaitingTime);

        yield return new WaitForSeconds(attackCooldown - attackWaitingTime);
        canAttack = true;
    }
}
