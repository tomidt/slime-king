using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PrimaryAttack : MonoBehaviour
{
    [SerializeField] private InputActionReference primaryAttack;
    [SerializeField] private FloatValue primaryAttackCooldown;
    [SerializeField] private GameObject projPrefab;

    private bool canAttack = true;
    private float currentCooldown = 0;

    private void Awake()
    {

    }

    private void Update()
    {
        if(!canAttack)
        {
            currentCooldown += Time.deltaTime;
            if(currentCooldown >= primaryAttackCooldown.value)
            {
                canAttack = true;
                currentCooldown = 0;
            }
        }

        if(canAttack && primaryAttack.action.ReadValue<float>() != 0)
        {
            canAttack = false;
            Attack();
        }
    }

    private void Attack()
    {
        Debug.Log("Attacked");
        Instantiate(projPrefab, transform.position, transform.rotation);
    }


    
}
