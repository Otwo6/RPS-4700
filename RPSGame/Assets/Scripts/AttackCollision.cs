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
            print("Attacking enemy");
            EnemyHealthScript enemyHealth = enemy.GetComponent<EnemyHealthScript>();
            Paperling paperling = enemy.GetComponent<Paperling>();

            if (paperling != null)
            {
				print("Paperloinmg");
                // Must be paperling
                if (attackType == 2) // Scissors attacks Paper
                {
					if(paperling.size == 2)
					{
						paperling.split(paperling.mediumPaperlingPrefab, 2);
						Destroy(enemy);

					}
					else if(paperling.size == 1)
					{
						paperling.split(paperling.smallPaperlingPrefab, 1);
						Destroy(enemy);

					}
					else
					{
						Destroy(enemy);
					}
                }
				else
				{
					print(attackType);
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
                if (attackType == 0) // Rock attacks Cutling
                {
                    // Destroy the cutling
                    Destroy(enemy);
                }
            }
        }
    }
}
