using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryProjectile : MonoBehaviour
{
    [SerializeField] private FloatValue projSpeed;
    [SerializeField] private FloatValue bounce;

    private Rigidbody2D rb;
    private Vector3 lastVelocity;

    private float lifeSpan;
    private int bounceNum;
    private bool canBounce;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = (transform.right * projSpeed.value);
        bounceNum = (int) bounce.value;
        lifeSpan = projSpeed.value / 2.5f;
        calcBounce();
        
        StartCoroutine(kill());
    }

    private void Update()
    {
        if(canBounce)
        {
            lastVelocity = rb.velocity;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(canBounce)
        {
            Vector3 dir = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
            rb.velocity = dir * lastVelocity.magnitude;
            bounceNum--;
            calcBounce();
        }
    }

    private void calcBounce()
    {
        canBounce = bounceNum > 0;
    }

    private IEnumerator kill()
    {
        yield return new WaitForSeconds(lifeSpan);
        Destroy(gameObject);
    }
}
