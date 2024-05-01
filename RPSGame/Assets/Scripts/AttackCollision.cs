using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollision : MonoBehaviour
{
    [SerializeField] int attackType;    // 0 Rock 1 Paper 2 Scissors

    void OnTriggerEnter(Collider col)
    {
        AttackEnemy(col.gameObject);
    }

    void OnCollisionEnter(Collision col)
    {
        AttackEnemy(col.gameObject);
    }

    void AttackEnemy(GameObject enemy)
    {
        if (enemy.CompareTag("Enemy"))
        {
            Debug.Log("Attacking enemy");
            EnemyHealthScript enemyHealth = enemy.GetComponent<EnemyHealthScript>();
            Paperling paperling = enemy.GetComponent<Paperling>();

            if (paperling != null)
            {
                // Must be paperling
                if (attackType == 0) // Rock attacks Paper
                {
                    // Destroy the paperling
                    Destroy(enemy);
                }
            }
            else if (enemyHealth != null)
            {
                // Must be stone enemy
                if (attackType == 1) // Paper attacks Rock
                {
                    // Reduce the health of the stone enemy
                    enemyHealth.health--;
                    if (enemyHealth.health <= 0)
                    {
                        // Destroy the stone enemy if its health drops to or below 0
                        Destroy(enemy);
                    }
                }
            }
            else
            {
                // Must be cutling
                if (attackType == 2) // Scissors attacks Cutling
                {
                    // Destroy the cutling
                    Destroy(enemy);
                }
            }
        }
    }
}
