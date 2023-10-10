using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private FloatValue enemyHealth;
    [SerializeField] private CircleCollider2D hitbox;

    private float health;

    private void Awake()
    {
        health = enemyHealth.value;
    }

    public void takeDamage()
    {

    }
}
