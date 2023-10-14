using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] private FloatValue enemyHealth;

    //protected int currentHealth, maxHealth;

    private void Awake()
    {
        initalizeHealth((int) enemyHealth.value);
        setIframes(0.25f);
    }

    private bool checkDead()
    {
        return currentHealth <= 0;
    }

    public override void damage()
    {
        //need to add sending damage
        currentHealth--;
        if(checkDead())
        {
            died();
        }
    }

    public override void died()
    {
        if(diedEvent != null)
        {
            diedEvent.Invoke();
        }

        Destroy(gameObject);
    }

}
