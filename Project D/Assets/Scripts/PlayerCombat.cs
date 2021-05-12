using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : CharacterScript
{
    private float currentX;
    private float previousX;
    private float currentY;
    private float previousY;

    private void Start()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
        attack = 70;
    }

    void FixedUpdate() //sets the currentAttackPoint to the direction the player is walking
    {
        currentX = transform.position.x;
        currentY = transform.position.y;

        if (currentX > previousX)
        {
            currentAttackPoint = attackPointRight;
        }

        if (currentX < previousX)
        {
            currentAttackPoint = attackPointLeft;
        }

        if (currentY > previousY)
        {
            currentAttackPoint = attackPointUp;
        }

        if (currentY < previousY)
        {
            currentAttackPoint = attackPointDown;
        }

        previousX = transform.position.x;
        previousY = transform.position.y;
    }

    private void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }
}