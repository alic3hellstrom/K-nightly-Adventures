using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private int damage = 10;

    private void OnTriggerStay2D(Collider2D other)
    {
        Console.Clear();

        if (player.GetComponent<PlayerAttack>().attacking == true)
        {
            print("Detected attacking");
        }
        if (other.CompareTag("Enemy"))
        {
            print("Detected enemy as enemy");
            print("Their name = " + other.name);
            print(other.name);
        }

        PlayerMovement pM = player.GetComponent<PlayerMovement>();
        Health hp = other.GetComponent<Health>();

        if (pM != null)
        {
            print("Check if grounded:");
            print(pM.CheckIfGrounded());
        }

        if (player.GetComponent<PlayerAttack>().attacking && other.CompareTag("Enemy") && pM.CheckIfGrounded())
        {
            print("Attacking Enemy" + other.name);
            print("HELLO WORLD");

            if (other.transform.position.x > player.transform.position.x && pM.lookingRight)
            {
                other.GetComponent<Rigidbody2D>().AddForce(new(2f, 1.5f), ForceMode2D.Impulse);
                hp.Damage(damage, false);
            }
            else if (other.transform.position.x < player.transform.position.x && !pM.lookingRight)
            {
                other.GetComponent<Rigidbody2D>().AddForce(new(-2f, 1.5f), ForceMode2D.Impulse);
                hp.Damage(damage, false);
            }
        }
    }
}