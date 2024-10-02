using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    [SerializeField] private float knockBack = .5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Health hp = other.GetComponent<Health>();

        if (hp != null)
        {
            //print("Attacking Enemy" + other.name);
            //print("HELLO WORLD");

            if (other.transform.position.x > this.transform.position.x)
            {
                other.GetComponent<Rigidbody2D>().AddForce(new(knockBack * 2, knockBack), ForceMode2D.Impulse);
            }
            else if (other.transform.position.x < this.transform.position.x)
            {
                other.GetComponent<Rigidbody2D>().AddForce(new(-knockBack * 2, knockBack), ForceMode2D.Impulse);
            }
            hp.Damage(damage);
        }
    }
}