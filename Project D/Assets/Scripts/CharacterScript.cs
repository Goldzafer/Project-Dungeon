using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public int attack;

    public Transform currentAttackPoint;
    public Transform attackPointUp;
    public Transform attackPointRight;
    public Transform attackPointDown;
    public Transform attackPointLeft;

    private float attackRange = 0.5f;
    public LayerMask enemyLayer;
    private Rigidbody2D enemyRigidbody;

    /*NOTE: this script is partially useless and messy because i used inheritance wrong,
      making using the functions and adding new things overcomplicated/impossible.*/

    protected void Attack() //attacks in the direction of "currentAttackPoint" based off the way the player is facing, see PlayerCombat 
    {
        //animation

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(currentAttackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.tag == ("Player"))
            {
                enemy.GetComponent<PlayerCombat>().TakeDamage(attack);
            }
            else 
            {
                enemy.GetComponent<EnemyCombat>().TakeDamage(attack);
                enemyRigidbody = enemy.GetComponent<Rigidbody2D>();
                enemyRigidbody.AddForce(transform.position * 50);
            }
        }
    }

    public void TakeDamage(int damage) //subtracts damage from attacked enemy, if health is bellow 0 checks if its the player or an enemy
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            if (this.tag == "player")
            {
                GameOver();
            }
            else
            {
                Die();
            }
        }
    }

    void Die() //disables the script and collider on the enemy
    {
        //death animation
        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }

    void GameOver()
    {
        //Game Over Screen
    }
}
