using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public bool resetHP, useCurrentHP;
    public float iframes;
    public UnityEvent healthChangedEvent, diedEvent;

    [SerializeField] protected FloatValue currentHealthRefrence;
    [SerializeField] protected FloatValue maxHealthRefrence;

    protected float currentHealth, maxHealth;
    protected float cTimer = 0;
    protected bool useIframes, isInvunerable, isDead;

    private void Start()
    {
        useIframes = iframes > 0;
        isInvunerable = isDead = false;

        if (!resetHP) return;

        if (useCurrentHP)
            currentHealthRefrence.value = maxHealthRefrence.value;
        else
            currentHealth = maxHealth;
    }
 
    public void takeDamage(float val)
    {
        if (isDead) return;
        if (useIframes && isInvunerable) return;

        if (useCurrentHP)
        {
            currentHealthRefrence.value += val;
            if (currentHealthRefrence.value <= 0)
                died();
        }
        else
        {
            currentHealth += val;
            if (currentHealth <= 0)
                died();
        }

        if (healthChangedEvent != null)
            healthChangedEvent.Invoke();
    }

    public virtual void died()
    {
        if (diedEvent != null)
            diedEvent.Invoke();

        Destroy(gameObject);
    }

    protected virtual void Update()
    {
        if (!isInvunerable) return;

        cTimer += Time.deltaTime;
        if (cTimer >= iframes)
        {
            cTimer = 0;
            isInvunerable = false;
        }
    }
}
