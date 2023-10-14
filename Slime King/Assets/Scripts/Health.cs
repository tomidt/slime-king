using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [Header("Health Varaibles")]
    public UnityEvent damagedEvent, diedEvent, healedEvent;

    protected int currentHealth, maxHealth;
    protected float iframes, cTimer;
    protected bool useIframes, isInvunerable, isDead;

    public void initalizeHealth(int health)
    {
        currentHealth = health;
        maxHealth = health;
    }

    public void setIframes(float value)
    {
        isDead = false;
        if(value > 0)
        {
            useIframes = true;
            isInvunerable = false;
            iframes = value;
            cTimer = 0;
        }
        else
        {
            useIframes = false;
        }
    }
 
    public void takeDamage()
    {
        if(useIframes && !isDead)
        {
            if (!isInvunerable)
            {
                invokeDamage();
            }
        }
        else
        {
            invokeDamage();
        }
    }

    private void invokeDamage()
    {
        if(damagedEvent != null)
        {
            damagedEvent.Invoke();
        }
        damage();
    }

    protected virtual void Update()
    {
        if(!isInvunerable) return;

        cTimer += Time.deltaTime;
        if (cTimer >= iframes)
        {
            cTimer = 0;
            isInvunerable = false;
        }
    }

    public virtual void damage() { }
    public virtual void died() { }
}
