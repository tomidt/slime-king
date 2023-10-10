using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hitbox : MonoBehaviour
{
    public bool playerDamage, enemyDamage;
    public UnityEvent hit;

    private void Awake()
    {
        if (hit == null)
        {
            hit = new UnityEvent();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!playerDamage && !enemyDamage)
        {
            hit.Invoke();
        }
        else if ((playerDamage && collision.CompareTag("PlayerDamage")) || (enemyDamage && collision.CompareTag("EnemyDamage")))
        {
            hit.Invoke();
        }
    }
}