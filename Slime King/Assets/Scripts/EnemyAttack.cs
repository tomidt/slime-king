using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private FloatValue primaryAttackCooldown;

    private float cooldown = 3f;
    private float currentCooldown = 0f;

    public virtual void Update()
    {
        currentCooldown += Time.deltaTime;
        if (currentCooldown >= cooldown)
        {
            currentCooldown = 0;
            Attack();
        }
    }

    public virtual void Attack()
    {
        Debug.Log("Attacked");
    }
}
