using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : CharacterScript
{
    private void Start()
    {
        maxHealth = 150;
        currentHealth = maxHealth;
        attack = 20;
    }
}
